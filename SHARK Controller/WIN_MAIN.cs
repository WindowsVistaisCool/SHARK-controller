using SharpDX.XInput;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace SHARK_Controller
{
    public partial class WIN_MAIN : Form
    {
        private Controller? controller;

        private string hostName;
        private int port;

        private bool sessionActive = false;
        private Thread? socketThread = null;
        private Thread? socketReciever = null;

        private bool socketConnected = false;

        private bool teleopRequest = false;
        private bool disableRequest = false;
        private bool killRequest = false;

        private bool isInTele = false;

        private readonly List<IThreadSafeModification> disconnectControlModifications = [];

        private HashSet<Keys> pressedKeys = [];

        public WIN_MAIN()
        {
            InitializeComponent();

            t_hostname.Text = MainSettings.Default.Hostname;
            nud_port.Value = MainSettings.Default.Port;
            hostName = t_hostname.Text;
            port = (int)nud_port.Value;

            //_ = new DarkModeForms.DarkModeCS(this)
            //{
            //    ColorMode = DarkModeForms.DarkModeCS.DisplayMode.DarkMode,
            //};

            ss_controller_Click(null, null);

            disconnectControlModifications = [
                new ThreadSafeModification<TextBox>(console, (c) => {
                    c.AppendText("[SHARK UI] Return from session.\r\n");
                    c.SelectionStart = c.Text.Length;
                    c.ScrollToCaret();
                }),
                new ThreadSafeModification<Button>(b_connect, (c) => {
                    c.Enabled = true;
                    c.Text = "Connect to Robot";
                }),
                new ThreadSafeModification<TextBox>(robotState, (c) => {
                    c.Text = "Disconnected";
                    c.BackColor = Color.FromKnownColor(KnownColor.Control);
                }),
                TSMPresets.SetEnabled(t_hostname, true),
                TSMPresets.SetEnabled(nud_port, true),
                new ThreadSafeModification<Button>(b_enable, (c) => {
                    c.Enabled = false;
                    c.Visible = false;
                    c.BackColor = Color.FromKnownColor(KnownColor.Control);
                }),
                new ThreadSafeModification<Button>(b_disable, (c) => {
                    c.Enabled = false;
                    c.Visible = false;
                    c.BackColor = Color.FromKnownColor(KnownColor.Control);
                }),
                TSMPresets.SetEnabled(b_kill, false)
            ];
        }

        private void RunSocketThread()
        {
            using TcpClient client = new();
            try
            {
                if (!controller!.IsConnected)
                {
                    throw new Exception("No controller detected. Exiting...");
                }

                client.Connect(hostName, port);
                using NetworkStream stream = client.GetStream();

                socketConnected = true;

                socketReciever = new Thread(() => RunSocketReciever(stream))
                {
                    IsBackground = true
                };
                socketReciever.Start();

                // update UI elements (safely)
                new TSMCollection([
                    new ThreadSafeModification<Button>(b_connect, (c) =>
                    {
                        c.Enabled = true;
                        ActiveControl = c;
                    }),
                    TSMPresets.SetEnabled(b_kill, true),
                    TSMPresets.SetVisible(b_enable, true),
                    TSMPresets.SetVisible(b_disable, true),
                ]).Apply();
                SetEnableButton(false);
                WriteConsole($"[SOCKET] Connected to {hostName}:{port}.");

                bool APressed = false;
                bool BPressed = false;
                bool YPressed = false;

                bool isTank = false;

                ss_robot.Text = "Robot connected.";
                ss_robot.BackColor = Color.Green;

                while (socketConnected)
                {
                    if (teleopRequest)
                    {
                        WriteData(stream, "tele");
                        teleopRequest = false;
                        continue;
                    }
                    if (disableRequest)
                    {
                        WriteData(stream, "dis");
                        disableRequest = false;
                        continue;
                    }

                    var state = controller.GetState();
                    var gamepad = state.Gamepad;

                    if (gamepad.Buttons == GamepadButtonFlags.Start)
                    {
                        WriteConsole("Disconnecting client.");
                        break;
                    }
                    if (gamepad.Buttons == GamepadButtonFlags.Back || killRequest)
                    {
                        WriteConsole("Killing Robot.");
                        killRequest = false;
                        WriteData(stream, "exit");
                        Thread.Sleep(100);
                        break;
                    }
                    if (gamepad.Buttons == GamepadButtonFlags.Y && !YPressed)
                    {
                        YPressed = true;
                        isInTele = false;
                        WriteData(stream, "auto");
                        continue;
                    }

                    // Switch robot centric mecanum vs. tank
                    if (gamepad.Buttons == GamepadButtonFlags.LeftThumb)
                    {
                        WriteConsole("Switching to Robot Centric MECANUM");
                        isTank = false;
                    }
                    else if (gamepad.Buttons == GamepadButtonFlags.RightThumb)
                    {
                        WriteConsole("Switching to TANK.");
                        isTank = true;
                    }

                    if (isInTele)
                    {
                        int leftX = RoundStick(NormalizeStick(gamepad.LeftThumbX));
                        int leftY = RoundStick(NormalizeStick(gamepad.LeftThumbY));
                        int rightX = RoundStick(NormalizeStick(gamepad.RightThumbX));
                        int rightY = RoundStick(NormalizeStick(gamepad.RightThumbY));

                        if (isTank)
                        {
                            //WriteJoystickConsole($"Tank Drive Parameters -  Left Stick: {leftY}  Right Stick: {rightY}");
                            WriteData(stream, $"te-t,{leftY},{rightY}");
                        }
                        else
                        {
                            //WriteJoystickConsole($"Mecanum Drive Parameters -  X: {leftX}  Y: {leftY}  Rot: {rightX}");
                            WriteData(stream, $"te-rc,{leftX},{leftY},{rightX}");
                        }
                    }

                    Thread.Sleep(50);

                    if (APressed && gamepad.Buttons != GamepadButtonFlags.A)
                        APressed = false;
                    if (BPressed && gamepad.Buttons != GamepadButtonFlags.B)
                        BPressed = false;
                    if (YPressed && gamepad.Buttons != GamepadButtonFlags.Y)
                        YPressed = false;
                }
            }
            catch (Exception ex)
            {
                WriteConsole($"[SOCKET] Error: {ex.Message}");
            }
            finally
            {
                client.Close();
                WriteConsole("[SOCKET] Connection closed.");
            }
            sessionActive = false;
            socketConnected = false;
            new TSMCollection(disconnectControlModifications).Apply();
            ss_robot.Text = "Robot disconnected.";
            ss_robot.BackColor = Color.Red;
            socketThread = null;
        }

        private void RunSocketReciever(NetworkStream stream)
        {
            try
            {
                WriteConsole($"[RECIEVER] Reciever connected.");
                while (socketConnected)
                {
                    byte[] buffer = new byte[256];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                    {
                        break;
                    }

                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead).Trim();

                    if (message.StartsWith("[STATE] "))
                    {
                        string stateMessage = message[8..];
                        WriteConsole($"{message}");
                        if (stateMessage == "DISABLE")
                        {
                            new ThreadSafeModification<TextBox>(robotState, (c) =>
                            {
                                c.Text = "DISABLED";
                                c.BackColor = Color.Red;
                            }).Apply();
                            isInTele = false;
                            SetEnableButton(false);
                        }
                        else if (stateMessage == "TELEOP")
                        {
                            new ThreadSafeModification<TextBox>(robotState, (c) =>
                            {
                                c.Text = "TELEOP";
                                c.BackColor = Color.Green;
                            }).Apply();
                            isInTele = true;
                            SetEnableButton(true);
                        }
                        else if (stateMessage == "AUTONOMOUS")
                        {
                            new ThreadSafeModification<TextBox>(robotState, (c) =>
                            {
                                c.Text = "AUTONOMOUS";
                                c.BackColor = Color.Yellow;
                            }).Apply();
                            isInTele = false;
                            SetEnableButton(true);
                        }
                    }
                    else if (message.StartsWith("[ROBOTINFO] "))
                    {
                        WriteRobotInfo($"{message[12..].Replace("\n", "\r\n")}");
                    }
                    else
                    {
                        WriteConsole($"{message}");
                    }
                }
            }
            catch (Exception ex)
            {
                WriteConsole($"[RECIEVER] Reciever Error: {ex.Message}");
            }
            finally
            {
                socketReciever = null;
                WriteConsole("[RECIEVER] Reciever closed.");
            }
        }

        private static float NormalizeStick(short value)
        {
            return Math.Clamp(value / 32767f, -1f, 1f);
        }

        private static int RoundStick(float value, float threshold = 0.6f)
        {
            if (value > threshold) return 1;
            if (value < -threshold) return -1;
            return 0;
        }

        private static void WriteData(NetworkStream stream, string message)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(message + "\n");
            stream.Write(bytes, 0, bytes.Length);
        }

        private void WriteConsole(string message)
        {
            new ThreadSafeModification<TextBox>(console, (c) =>
            {
                c.AppendText(message + "\r\n");
                c.SelectionStart = c.Text.Length;
                c.ScrollToCaret();
            }).Apply();
        }

        private void WriteRobotInfo(string message)
        {
            new ThreadSafeModification<TextBox>(robotInfo, (c) =>
            {
                c.AppendText(message + "\r\n");
            }).Apply();
        }

        private void SetEnableButton(bool enable)
        {
            new TSMCollection([
                new ThreadSafeModification<Button>(b_enable, (c) =>
                {
                    c.BackColor = enable ? Color.LightGreen : Color.FromKnownColor(KnownColor.Control);
                    c.Enabled = !enable;
                    if (enable)
                    {
                        ActiveControl = b_disable;
                    }
                }),
                new ThreadSafeModification<Button>(b_disable, (c) =>
                {
                    c.BackColor = enable ? Color.FromKnownColor(KnownColor.Control) : Color.Tomato;
                    c.Enabled = enable;
                    if (!enable)
                    {
                        ActiveControl = c;
                    }
                })
            ]).Apply();
        }

        private void connect_Click(object sender, EventArgs e)
        {
            if (t_hostname.Text == "" || port < nud_port.Minimum || port > nud_port.Maximum)
            {
                MessageBox.Show("Please enter a valid hostname and port.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sessionActive = false;
                return;
            }

            sessionActive = !sessionActive;
            hostName = t_hostname.Text;
            port = (int)nud_port.Value;
            t_hostname.Enabled = !sessionActive;
            nud_port.Enabled = !sessionActive;
            if (sessionActive)
            {
                ss_controller_Click(null, null);

                b_connect.Text = "Disconnect";
                console.Text = "";
                robotInfo.Text = "";
                robotState.Text = "Connecting";
                robotState.BackColor = Color.SandyBrown;
                b_connect.Enabled = false;
                b_enable.Enabled = false;
                b_enable.BackColor = Color.FromKnownColor(KnownColor.Control);
                b_disable.Enabled = false;
                b_disable.BackColor = Color.FromKnownColor(KnownColor.Control);

                MainSettings.Default.Hostname = hostName;
                MainSettings.Default.Port = port;
                MainSettings.Default.Save();

                AddConsoleText("[SHARK UI] New session created.");
                socketThread = new Thread(RunSocketThread)
                {
                    IsBackground = true
                };
                socketThread.Start();
            }
            else
            {
                socketConnected = false;
                b_connect.Text = "Connect to Robot";
                AddConsoleText("[SHARK UI] Return from session.");
            }
        }
        private void clearConsole_Click(object sender, EventArgs e)
        {
            console.Text = "";
        }

        private void AddConsoleText(string message)
        {
            console.Text += message + "\r\n";
            console.SelectionStart = console.Text.Length;
            console.ScrollToCaret();
        }

        private void ss_label_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Written by Kyle Rush.", "About SHARK Controller", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ss_controller_Click(object? sender, EventArgs? e)
        {
            controller = new Controller(UserIndex.One);
            if (controller.IsConnected)
            {
                ss_controller.Text = "Controller connected.";
                ss_controller.BackColor = Color.LightGreen;
            }
            else
            {
                ss_controller.Text = "Controller disconnected.";
                ss_controller.BackColor = Color.Red;
                AddConsoleText("[SHARK UI] WARNING! No controller detected.\r\nClick the controller text in the status bar to rescan.");
            }
        }

        private void WIN_MAIN_FormClosing(object sender, FormClosingEventArgs e)
        {
            sessionActive = false;
            socketConnected = false;
        }

        private void robotState_Enter(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        private void b_enable_Click(object sender, EventArgs e)
        {
            teleopRequest = true;

        }

        private void b_disable_Click(object sender, EventArgs e)
        {
            disableRequest = true;
        }
        private void b_kill_Click(object sender, EventArgs e)
        {
            killRequest = true;
        }

        private void WIN_MAIN_KeyDown(object sender, KeyEventArgs e)
        {
            pressedKeys.Add(e.KeyCode);

            if (e.KeyCode == Keys.Enter)
            {
                disableRequest = true;
                e.Handled = true;
            }

            else if (e.KeyCode == Keys.Space)
            {
                //e.Handled = true;
            }

            if (b_enable.Enabled && pressedKeys.Contains(Keys.OemPipe) && pressedKeys.Contains(Keys.Oem6) && pressedKeys.Contains(Keys.Oem4))
            {
                b_enable.PerformClick();
                e.Handled = true;
            }
        }

        private void WIN_MAIN_KeyUp(object sender, KeyEventArgs e)
        {
            pressedKeys.Remove(e.KeyCode);
        }
    }
}
