using SharpDX.XInput;
using System.Diagnostics;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace SHARK_Controller
{
    public partial class WIN_MAIN : Form
    {
        private Controller? controller;
        private bool bypassJoystick = false;

        private string hostName;
        private int port;

        private bool sessionActive = false;
        private Thread? socketThread = null;
        private Thread? socketReciever = null;

        private bool socketConnected = false;

        private bool teleopRequest = false;
        private bool autoRequest = false;
        private bool disableRequest = false;
        private bool killRequest = false;

        private bool isInTele = false;

        private readonly TSMCollection connectControlModifications = new();
        private readonly TSMCollection disconnectControlModifications = new();

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

            connectControlModifications = new TSMCollection([
                new ThreadSafeModification<Button>(b_connect, (c) =>
                {
                    c.Enabled = true;
                    ActiveControl = c;
                    ms_robot.Enabled = true;
                }),
                TSMPresets.SetEnabled(b_kill, true),
                TSMPresets.SetVisible(b_teleop, true),
                TSMPresets.SetVisible(b_auton, true),
                TSMPresets.SetVisible(b_disable, true),
            ]);

            disconnectControlModifications = new TSMCollection([
                new ThreadSafeModification<TextBox>(console, (c) => {
                    ms_robot.Enabled = false;                    c.AppendText("[SHARK UI] Return from session.\r\n");
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
                new ThreadSafeModification<Button>(b_teleop, (c) => {
                    c.Enabled = false;
                    c.Visible = false;
                    c.BackColor = Color.FromKnownColor(KnownColor.Control);
                }),
                new ThreadSafeModification<Button>(b_auton, (c) => {
                    c.Enabled = false;
                    c.Visible = false;
                    c.BackColor = Color.FromKnownColor(KnownColor.Control);
                }),
                new ThreadSafeModification<Button>(b_disable, (c) => {
                    c.Enabled = false;
                    c.Visible = false;
                    c.BackColor = Color.FromKnownColor(KnownColor.Control);
                }),
                TSMPresets.SetEnabled(b_kill, false),
                TSMPresets.SetVisible(b_startCode, true)
            ]);
        }

        private void RunSocketThread()
        {
            using TcpClient client = new();
            try
            {
                if (!controller!.IsConnected && !bypassJoystick)
                {
                    throw new Exception("No controller detected. Exiting...");
                }
                else if (bypassJoystick)
                {
                    WriteConsole("[SOCKET] WARNING! Bypassing joystick input.");
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
                connectControlModifications.Apply();
                SetEnableButton(false);
                WriteConsole($"[SOCKET] Connected to {hostName}:{port}.");

                HashSet<GamepadButtonFlags> pressedButtons = [];

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
                    if (autoRequest)
                    {
                        WriteData(stream, "auto");
                        autoRequest = false;
                        continue;
                    }
                    if (disableRequest)
                    {
                        WriteData(stream, "dis");
                        disableRequest = false;
                        continue;
                    }
                    if (killRequest)
                    {
                        WriteConsole("Killing Robot.");
                        killRequest = false;
                        WriteData(stream, "exit");
                        Thread.Sleep(100);
                        break;
                    }
                    if (bypassJoystick)
                    {
                        continue;
                    }

                    var state = controller.GetState();
                    var gamepad = state.Gamepad;

                    if (gamepad.Buttons == GamepadButtonFlags.Start)
                    {
                        WriteConsole("Disconnecting client.");
                        break;
                    }

                    // Only send joystick data in teleop
                    if (isInTele)
                    {
                        // Send stick data
                        int leftX = RoundStick(NormalizeStick(gamepad.LeftThumbX));
                        int leftY = RoundStick(NormalizeStick(gamepad.LeftThumbY));
                        int rightX = RoundStick(NormalizeStick(gamepad.RightThumbX));
                        int rightY = RoundStick(NormalizeStick(gamepad.RightThumbY));
                        int triggerL = RoundStick(gamepad.LeftTrigger, 75f);
                        int triggerR = RoundStick(gamepad.RightTrigger, 75f);

                        WriteData(stream, $"te-jstk,{leftX},{leftY},{rightX},{rightY},{triggerL},{triggerR};");

                        Thread.Sleep(25);

                        // Send button data
                        foreach (var button in Enum.GetValues(typeof(GamepadButtonFlags)).Cast<GamepadButtonFlags>())
                        {
                            if (gamepad.Buttons.HasFlag(button) && !pressedButtons.Contains(button))
                            {
                                pressedButtons.Add(button);
                                WriteData(stream, $"te-btn,{button};");
                            }
                            else if (!gamepad.Buttons.HasFlag(button) && pressedButtons.Contains(button))
                            {
                                pressedButtons.Remove(button);
                                WriteData(stream, $"te-btn,-{button};");
                            }
                        }
                    }

                    Thread.Sleep(25);
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
            disconnectControlModifications.Apply();
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

        private static int RoundStick(float value, float threshold = 0.55f)
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
                try
                {
                    c.AppendText(message + "\r\n");
                    c.SelectionStart = c.Text.Length;
                    c.ScrollToCaret();
                }
                catch { }
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
                new ThreadSafeModification<Button>(b_teleop, (c) =>
                {
                    c.BackColor = isInTele ? Color.LightGreen : Color.FromKnownColor(KnownColor.Control);
                    c.Enabled = !isInTele;
                    if (enable)
                    {
                        ActiveControl = b_disable;
                    }
                }),
                new ThreadSafeModification<Button>(b_auton, (c) =>
                {
                    c.BackColor = enable && !isInTele ? Color.Khaki : Color.FromKnownColor(KnownColor.Control);
                    c.Enabled = !enable || isInTele;
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

        private void ConnectButtonClicked(object sender, EventArgs e)
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
                b_startCode.Visible = false;
                b_connect.Enabled = false;
                b_teleop.Enabled = false;
                b_teleop.BackColor = Color.FromKnownColor(KnownColor.Control);
                b_auton.Enabled = false;
                b_auton.BackColor = Color.FromKnownColor(KnownColor.Control);
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
            if (joystick_bypass.Checked)
            {
                if (e != null)
                {
                    bypassJoystick = false;
                    joystick_bypass.Checked = false;
                }
                else
                {
                    return;
                }
            }
            controller = new Controller(UserIndex.One);
            if (controller.IsConnected)
            {
                ss_controller.Text = "Controller connected.";
                ss_controller.BackColor = Color.Green;
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

        private void b_teleop_Click(object sender, EventArgs e)
        {
            teleopRequest = true;

        }

        private void b_auton_Click(object sender, EventArgs e)
        {
            autoRequest = true;
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

            if (b_teleop.Enabled && pressedKeys.Contains(Keys.OemPipe) && pressedKeys.Contains(Keys.Oem6) && pressedKeys.Contains(Keys.Oem4))
            {
                b_teleop.PerformClick();
                e.Handled = true;
            }
        }

        private void WIN_MAIN_KeyUp(object sender, KeyEventArgs e)
        {
            pressedKeys.Remove(e.KeyCode);
        }

        private void b_startCode_Click(object sender, EventArgs e)
        {
            if (t_hostname.Text.ToLower() != "shark")
            {
                MessageBox.Show("This is only supported on the offical S.H.A.R.K.!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Process sshProcess = Process.Start("cmd.exe");
            sshProcess.StartInfo.Arguments = $"/c ssh pi@{t_hostname.Text} \"cd /home/pi/robot && python3 Main.py\"";
            sshProcess.Start();
        }

        private void robot_customPacket_Click(object sender, EventArgs e)
        {
            new WIN_CustomPacket().ShowDialog();
        }

        private void robot_auton_Click(object sender, EventArgs e)
        {

        }

        private void joystick_bypass_Click(object sender, EventArgs e)
        {
            bypassJoystick = joystick_bypass.Checked;

            ss_controller.Text = bypassJoystick ? "Controller Bypassed." : "Controller Connected.";
            ss_controller.BackColor = Color.Gray;

            if (!bypassJoystick)
            {
                ss_controller_Click(null, null);
            }
        }
    }

}
