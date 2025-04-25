using SharpDX.XInput;
using System.Net.Sockets;
using System.Text;

namespace SHARK_Controller
{
    public partial class WIN_MAIN : Form
    {
        private Controller controller;

        private string hostName = "QuackStation";
        private int port = 8008;

        private bool sessionActive = false;
        private Thread? socketThread = null;

        private bool socketConnected = false;

        private List<IThreadSafeModification> disconnectControlModifications = [];

        public WIN_MAIN()
        {
            InitializeComponent();

            console.Text = "";

            ss_controller_Click(null, null);

            disconnectControlModifications = [
                new ThreadSafeModification<TextBox>(console, (c) => {
                    c.AppendText("[SHARK UI] Return from session.\r\n");
                    c.SelectionStart = c.Text.Length;
                    c.ScrollToCaret();
                }),
                new ThreadSafeModification<TextBox>(joystickConsole, (c) => c.Text = "Joystick disabled."),
                new ThreadSafeModification<Button>(b_connect, (c) => c.Text = "Connect to Robot"),
                new ThreadSafeModification<TextBox>(t_hostname, (c) => c.Enabled = true),
                new ThreadSafeModification<NumericUpDown>(nud_port, (c) => c.Enabled = true)
            ];
        }

        private void RunSocketThread()
        {
            using TcpClient client = new();
            try
            {
                client.Connect(hostName, port);
                using NetworkStream stream = client.GetStream();

                bool APressed = false;
                bool BPressed = false;

                bool isInTele = false;
                bool isTank = false;

                ss_robot.Text = "Robot connected.";
                ss_robot.BackColor = Color.Green;

                socketConnected = true;

                WriteConsole($"[SOCKET] Connection opened to {hostName}:{port}.");
                WriteJoystickConsole("Joystick enabled.");
                while (socketConnected)
                {
                    var state = controller.GetState();
                    var gamepad = state.Gamepad;

                    if (gamepad.Buttons == GamepadButtonFlags.Start)
                    {
                        WriteConsole("Disconnecting client.");
                        WriteJoystickConsole("[START] Disconnecting client.");
                        break;
                    }
                    if (gamepad.Buttons == GamepadButtonFlags.Back)
                    {
                        WriteConsole("Killing Robot.");
                        WriteJoystickConsole("[BACK] Killing Robot.");
                        WriteData(stream, "exit");
                        Thread.Sleep(100);
                        break;
                    }
                    if (gamepad.Buttons == GamepadButtonFlags.A && !APressed)
                    {
                        APressed = true;
                        isInTele = false;
                        WriteConsole("Robot Disabled.");
                        WriteJoystickConsole("[A] Disable Robot.");
                        WriteData(stream, "dis");
                        continue;
                    }
                    if (gamepad.Buttons == GamepadButtonFlags.B && !BPressed)
                    {
                        BPressed = true;
                        isInTele = true;
                        WriteConsole("Robot Enabled Teleop.");
                        WriteJoystickConsole("[B] Enable Teleop.");
                        WriteData(stream, "tele");
                        continue;
                    }

                    // Switch robot centric mecanum vs. tank
                    if (gamepad.Buttons == GamepadButtonFlags.LeftThumb)
                    {
                        WriteJoystickConsole("Switching to Robot Centric MECANUM");
                        isTank = false;
                    }
                    else if (gamepad.Buttons == GamepadButtonFlags.RightThumb)
                    {
                        WriteJoystickConsole("Switching to TANK.");
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
                            WriteJoystickConsole($"Tank Drive Parameters -  Left Stick: {leftY}  Right Stick: {rightY}");
                            WriteData(stream, $"te-t,{leftY},{rightY}");
                        }
                        else
                        {
                            WriteJoystickConsole($"Mecanum Drive Parameters -  X: {leftX}  Y: {leftY}  Rot: {rightX}");
                            WriteData(stream, $"te-rc,{leftX},{leftY},{rightX}");
                        }
                    }

                    Thread.Sleep(50);

                    if (APressed && gamepad.Buttons != GamepadButtonFlags.A)
                        APressed = false;
                    if (BPressed && gamepad.Buttons != GamepadButtonFlags.B)
                        BPressed = false;
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

        private void WriteJoystickConsole(string message)
        {
            new ThreadSafeModification<TextBox>(joystickConsole, (c) =>
            {
                c.AppendText(message + "\r\n");
                c.SelectionStart = c.Text.Length;
                c.ScrollToCaret();
            }).Apply(); 
        }

        private void connect_Click(object sender, EventArgs e)
        {
            sessionActive = !sessionActive;
            hostName = t_hostname.Text;
            port = (int)nud_port.Value;
            t_hostname.Enabled = !sessionActive;
            nud_port.Enabled = !sessionActive;
            if (sessionActive)
            {
                b_connect.Text = "Disconnect";
                console.Text = "";
                joystickConsole.Text = "";
                AddConsoleText("[SHARK UI] New session created.");
                socketThread = new Thread(RunSocketThread);
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

        private void AddJoystickConsoleText(string message)
        {
            joystickConsole.Text += message + "\r\n";
            joystickConsole.SelectionStart = joystickConsole.Text.Length;
            joystickConsole.ScrollToCaret();
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
                AddConsoleText("[SHARK UI] Controller connected successfully.");
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
            socketThread?.Join();
        }
    }
}
