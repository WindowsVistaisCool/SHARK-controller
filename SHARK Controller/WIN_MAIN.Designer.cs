namespace SHARK_Controller
{
    partial class WIN_MAIN
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WIN_MAIN));
            ss = new StatusStrip();
            ss_label = new ToolStripStatusLabel();
            ss_robot = new ToolStripStatusLabel();
            ss_controller = new ToolStripStatusLabel();
            p_main = new Panel();
            tlp_main = new TableLayoutPanel();
            console = new TextBox();
            ls_console = new Label();
            t_hostname = new TextBox();
            l_hostname = new Label();
            l_port = new Label();
            nud_port = new NumericUpDown();
            b_connect = new Button();
            b_clearConsole = new Button();
            robotInfo = new TextBox();
            ls_robotInfo = new Label();
            robotState = new TextBox();
            l_status = new Label();
            b_enable = new Button();
            b_disable = new Button();
            b_kill = new Button();
            b_startCode = new Button();
            ms = new MenuStrip();
            ms_joystick = new ToolStripMenuItem();
            joystick_rescan = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            joystick_bypass = new ToolStripMenuItem();
            joystick_configure = new ToolStripMenuItem();
            ms_robot = new ToolStripMenuItem();
            robot_customPacket = new ToolStripMenuItem();
            robot_auton = new ToolStripComboBox();
            ms_help = new ToolStripMenuItem();
            help_about = new ToolStripMenuItem();
            ss.SuspendLayout();
            p_main.SuspendLayout();
            tlp_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_port).BeginInit();
            ms.SuspendLayout();
            SuspendLayout();
            // 
            // ss
            // 
            ss.ImageScalingSize = new Size(18, 18);
            ss.Items.AddRange(new ToolStripItem[] { ss_label, ss_robot, ss_controller });
            ss.Location = new Point(0, 450);
            ss.Name = "ss";
            ss.Size = new Size(819, 33);
            ss.SizingGrip = false;
            ss.TabIndex = 1;
            ss.Text = "S.H.A.R.K. Controller v1.0 - ";
            // 
            // ss_label
            // 
            ss_label.Font = new Font("Segoe UI", 10F);
            ss_label.Image = (Image)resources.GetObject("ss_label.Image");
            ss_label.Margin = new Padding(8, 5, 50, 8);
            ss_label.Name = "ss_label";
            ss_label.Size = new Size(189, 20);
            ss_label.Text = "S.H.A.R.K. Controller v1.0";
            ss_label.Click += ss_label_Click;
            // 
            // ss_robot
            // 
            ss_robot.BackColor = Color.Red;
            ss_robot.Font = new Font("Segoe UI", 10F);
            ss_robot.Image = (Image)resources.GetObject("ss_robot.Image");
            ss_robot.Margin = new Padding(8, 5, 50, 8);
            ss_robot.Name = "ss_robot";
            ss_robot.Size = new Size(165, 20);
            ss_robot.Text = "Robot Disconnected.";
            // 
            // ss_controller
            // 
            ss_controller.BackColor = Color.Red;
            ss_controller.Font = new Font("Segoe UI", 10F);
            ss_controller.Image = (Image)resources.GetObject("ss_controller.Image");
            ss_controller.Margin = new Padding(8, 5, 50, 8);
            ss_controller.Name = "ss_controller";
            ss_controller.Size = new Size(190, 20);
            ss_controller.Text = "Controller Disconnected.";
            ss_controller.Click += ss_controller_Click;
            // 
            // p_main
            // 
            p_main.Controls.Add(tlp_main);
            p_main.Dock = DockStyle.Fill;
            p_main.Location = new Point(0, 25);
            p_main.Name = "p_main";
            p_main.Padding = new Padding(10, 5, 10, 5);
            p_main.Size = new Size(819, 425);
            p_main.TabIndex = 2;
            // 
            // tlp_main
            // 
            tlp_main.AutoSize = true;
            tlp_main.BackColor = Color.Transparent;
            tlp_main.ColumnCount = 5;
            tlp_main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tlp_main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 177F));
            tlp_main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 27F));
            tlp_main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 262F));
            tlp_main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 134F));
            tlp_main.Controls.Add(console, 0, 7);
            tlp_main.Controls.Add(ls_console, 0, 6);
            tlp_main.Controls.Add(t_hostname, 3, 1);
            tlp_main.Controls.Add(l_hostname, 3, 0);
            tlp_main.Controls.Add(l_port, 4, 0);
            tlp_main.Controls.Add(nud_port, 4, 1);
            tlp_main.Controls.Add(b_connect, 0, 0);
            tlp_main.Controls.Add(b_clearConsole, 4, 6);
            tlp_main.Controls.Add(robotInfo, 3, 4);
            tlp_main.Controls.Add(ls_robotInfo, 3, 3);
            tlp_main.Controls.Add(robotState, 0, 4);
            tlp_main.Controls.Add(l_status, 0, 3);
            tlp_main.Controls.Add(b_enable, 0, 5);
            tlp_main.Controls.Add(b_disable, 1, 5);
            tlp_main.Controls.Add(b_kill, 4, 3);
            tlp_main.Controls.Add(b_startCode, 3, 6);
            tlp_main.Dock = DockStyle.Fill;
            tlp_main.Location = new Point(10, 5);
            tlp_main.Name = "tlp_main";
            tlp_main.RowCount = 8;
            tlp_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tlp_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tlp_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 7F));
            tlp_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
            tlp_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tlp_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tlp_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tlp_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tlp_main.Size = new Size(799, 415);
            tlp_main.TabIndex = 0;
            // 
            // console
            // 
            console.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            console.BackColor = SystemColors.InactiveCaptionText;
            console.BorderStyle = BorderStyle.FixedSingle;
            tlp_main.SetColumnSpan(console, 5);
            console.Font = new Font("Lucida Sans Typewriter", 10.18868F, FontStyle.Regular, GraphicsUnit.Point, 0);
            console.ForeColor = Color.LawnGreen;
            console.Location = new Point(5, 266);
            console.Margin = new Padding(5);
            console.Multiline = true;
            console.Name = "console";
            console.ReadOnly = true;
            console.ScrollBars = ScrollBars.Vertical;
            console.Size = new Size(790, 144);
            console.TabIndex = 0;
            console.TabStop = false;
            console.Text = "** Welcome to the S.H.A.R.K. Controller! **\r\n** Written by Kyle Rush **\r\n";
            // 
            // ls_console
            // 
            ls_console.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ls_console.AutoSize = true;
            ls_console.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            ls_console.Location = new Point(3, 241);
            ls_console.Name = "ls_console";
            ls_console.Size = new Size(63, 20);
            ls_console.TabIndex = 1;
            ls_console.Text = "Console";
            // 
            // t_hostname
            // 
            t_hostname.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            t_hostname.Location = new Point(407, 40);
            t_hostname.Name = "t_hostname";
            t_hostname.Size = new Size(256, 25);
            t_hostname.TabIndex = 4;
            t_hostname.Text = "QuackStation";
            // 
            // l_hostname
            // 
            l_hostname.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            l_hostname.AutoSize = true;
            l_hostname.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            l_hostname.Location = new Point(407, 14);
            l_hostname.Name = "l_hostname";
            l_hostname.Size = new Size(97, 20);
            l_hostname.TabIndex = 5;
            l_hostname.Text = "Hostname/IP";
            // 
            // l_port
            // 
            l_port.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            l_port.AutoSize = true;
            l_port.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            l_port.Location = new Point(669, 14);
            l_port.Name = "l_port";
            l_port.Size = new Size(37, 20);
            l_port.TabIndex = 6;
            l_port.Text = "Port";
            // 
            // nud_port
            // 
            nud_port.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nud_port.Location = new Point(669, 40);
            nud_port.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nud_port.Name = "nud_port";
            nud_port.Size = new Size(128, 25);
            nud_port.TabIndex = 7;
            nud_port.Value = new decimal(new int[] { 8008, 0, 0, 0 });
            // 
            // b_connect
            // 
            b_connect.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlp_main.SetColumnSpan(b_connect, 2);
            b_connect.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            b_connect.Location = new Point(3, 3);
            b_connect.Name = "b_connect";
            tlp_main.SetRowSpan(b_connect, 2);
            b_connect.Size = new Size(371, 66);
            b_connect.TabIndex = 2;
            b_connect.Text = "Connect to Robot";
            b_connect.UseVisualStyleBackColor = true;
            b_connect.Click += ConnectButtonClicked;
            // 
            // b_clearConsole
            // 
            b_clearConsole.Anchor = AnchorStyles.Right;
            b_clearConsole.AutoSize = true;
            b_clearConsole.Location = new Point(698, 229);
            b_clearConsole.Name = "b_clearConsole";
            b_clearConsole.Size = new Size(99, 27);
            b_clearConsole.TabIndex = 10;
            b_clearConsole.Text = "Clear Console";
            b_clearConsole.UseVisualStyleBackColor = true;
            b_clearConsole.Click += clearConsole_Click;
            // 
            // robotInfo
            // 
            robotInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            robotInfo.BorderStyle = BorderStyle.FixedSingle;
            tlp_main.SetColumnSpan(robotInfo, 2);
            robotInfo.Font = new Font("Segoe UI", 10.18868F);
            robotInfo.Location = new Point(409, 123);
            robotInfo.Margin = new Padding(5);
            robotInfo.Multiline = true;
            robotInfo.Name = "robotInfo";
            robotInfo.ReadOnly = true;
            tlp_main.SetRowSpan(robotInfo, 2);
            robotInfo.ScrollBars = ScrollBars.Vertical;
            robotInfo.Size = new Size(386, 97);
            robotInfo.TabIndex = 9;
            robotInfo.TabStop = false;
            // 
            // ls_robotInfo
            // 
            ls_robotInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ls_robotInfo.AutoSize = true;
            ls_robotInfo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            ls_robotInfo.Location = new Point(407, 98);
            ls_robotInfo.Name = "ls_robotInfo";
            ls_robotInfo.Size = new Size(135, 20);
            ls_robotInfo.TabIndex = 8;
            ls_robotInfo.Text = "Robot Information";
            // 
            // robotState
            // 
            robotState.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            robotState.BorderStyle = BorderStyle.FixedSingle;
            robotState.CausesValidation = false;
            tlp_main.SetColumnSpan(robotState, 2);
            robotState.Font = new Font("Segoe UI Black", 14.2641506F, FontStyle.Bold, GraphicsUnit.Point, 0);
            robotState.Location = new Point(3, 121);
            robotState.Name = "robotState";
            robotState.ReadOnly = true;
            robotState.ShortcutsEnabled = false;
            robotState.Size = new Size(371, 36);
            robotState.TabIndex = 12;
            robotState.TabStop = false;
            robotState.Text = "Disconnected";
            robotState.TextAlign = HorizontalAlignment.Center;
            robotState.WordWrap = false;
            robotState.Enter += robotState_Enter;
            // 
            // l_status
            // 
            l_status.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            l_status.AutoSize = true;
            tlp_main.SetColumnSpan(l_status, 2);
            l_status.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            l_status.Location = new Point(3, 98);
            l_status.Name = "l_status";
            l_status.Size = new Size(95, 20);
            l_status.TabIndex = 11;
            l_status.Text = "Robot Status";
            // 
            // b_enable
            // 
            b_enable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            b_enable.BackColor = SystemColors.Control;
            b_enable.Enabled = false;
            b_enable.FlatStyle = FlatStyle.Popup;
            b_enable.Font = new Font("Segoe UI", 18.3396225F);
            b_enable.Location = new Point(83, 165);
            b_enable.Margin = new Padding(0, 10, 0, 10);
            b_enable.Name = "b_enable";
            b_enable.Size = new Size(117, 50);
            b_enable.TabIndex = 13;
            b_enable.Text = "Enable";
            b_enable.UseVisualStyleBackColor = false;
            b_enable.Visible = false;
            b_enable.Click += b_enable_Click;
            // 
            // b_disable
            // 
            b_disable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            b_disable.BackColor = SystemColors.Control;
            b_disable.Enabled = false;
            b_disable.FlatStyle = FlatStyle.Popup;
            b_disable.Font = new Font("Segoe UI", 18.3396225F);
            b_disable.Location = new Point(200, 165);
            b_disable.Margin = new Padding(0, 10, 0, 10);
            b_disable.Name = "b_disable";
            b_disable.Size = new Size(117, 50);
            b_disable.TabIndex = 14;
            b_disable.Text = "Disable";
            b_disable.UseVisualStyleBackColor = false;
            b_disable.Visible = false;
            b_disable.Click += b_disable_Click;
            // 
            // b_kill
            // 
            b_kill.Anchor = AnchorStyles.Right;
            b_kill.AutoSize = true;
            b_kill.Enabled = false;
            b_kill.Location = new Point(687, 85);
            b_kill.Name = "b_kill";
            b_kill.Size = new Size(110, 27);
            b_kill.TabIndex = 15;
            b_kill.Text = "Kill Robot Code";
            b_kill.UseVisualStyleBackColor = true;
            b_kill.Click += b_kill_Click;
            // 
            // b_startCode
            // 
            b_startCode.Anchor = AnchorStyles.Left;
            b_startCode.AutoSize = true;
            b_startCode.Location = new Point(407, 229);
            b_startCode.Name = "b_startCode";
            b_startCode.Size = new Size(155, 27);
            b_startCode.TabIndex = 16;
            b_startCode.Text = "Start Robot Code (SSH)";
            b_startCode.UseVisualStyleBackColor = true;
            b_startCode.Click += b_startCode_Click;
            // 
            // ms
            // 
            ms.ImageScalingSize = new Size(18, 18);
            ms.Items.AddRange(new ToolStripItem[] { ms_joystick, ms_robot, ms_help });
            ms.Location = new Point(0, 0);
            ms.Name = "ms";
            ms.Size = new Size(819, 25);
            ms.TabIndex = 1;
            ms.Text = "menuStrip1";
            // 
            // ms_joystick
            // 
            ms_joystick.DropDownItems.AddRange(new ToolStripItem[] { joystick_rescan, toolStripSeparator1, joystick_bypass, joystick_configure });
            ms_joystick.Name = "ms_joystick";
            ms_joystick.Size = new Size(64, 21);
            ms_joystick.Text = "&Joystick";
            // 
            // joystick_rescan
            // 
            joystick_rescan.Name = "joystick_rescan";
            joystick_rescan.Size = new Size(170, 24);
            joystick_rescan.Text = "&Rescan";
            joystick_rescan.Click += ss_controller_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(167, 6);
            // 
            // joystick_bypass
            // 
            joystick_bypass.CheckOnClick = true;
            joystick_bypass.Name = "joystick_bypass";
            joystick_bypass.Size = new Size(170, 24);
            joystick_bypass.Text = "&Bypass Joystick";
            joystick_bypass.Click += joystick_bypass_Click;
            // 
            // joystick_configure
            // 
            joystick_configure.Name = "joystick_configure";
            joystick_configure.Size = new Size(170, 24);
            joystick_configure.Text = "&Configure/Test";
            // 
            // ms_robot
            // 
            ms_robot.DropDownItems.AddRange(new ToolStripItem[] { robot_customPacket, robot_auton });
            ms_robot.Enabled = false;
            ms_robot.Name = "ms_robot";
            ms_robot.Size = new Size(56, 21);
            ms_robot.Text = "&Robot";
            // 
            // robot_customPacket
            // 
            robot_customPacket.Name = "robot_customPacket";
            robot_customPacket.Size = new Size(200, 24);
            robot_customPacket.Text = "Send &Custom Packet";
            robot_customPacket.Click += robot_customPacket_Click;
            // 
            // robot_auton
            // 
            robot_auton.DropDownStyle = ComboBoxStyle.DropDownList;
            robot_auton.Items.AddRange(new object[] { "Autonomous 1", "Autonomous 2" });
            robot_auton.Name = "robot_auton";
            robot_auton.Size = new Size(121, 25);
            robot_auton.Click += robot_auton_Click;
            // 
            // ms_help
            // 
            ms_help.DropDownItems.AddRange(new ToolStripItem[] { help_about });
            ms_help.Name = "ms_help";
            ms_help.Size = new Size(47, 21);
            ms_help.Text = "&Help";
            // 
            // help_about
            // 
            help_about.Name = "help_about";
            help_about.Size = new Size(198, 24);
            help_about.Text = "&About";
            help_about.Click += ss_label_Click;
            // 
            // WIN_MAIN
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(819, 483);
            Controls.Add(p_main);
            Controls.Add(ms);
            Controls.Add(ss);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MainMenuStrip = ms;
            Name = "WIN_MAIN";
            StartPosition = FormStartPosition.CenterParent;
            Text = "S.H.A.R.K. Controller";
            FormClosing += WIN_MAIN_FormClosing;
            KeyDown += WIN_MAIN_KeyDown;
            KeyUp += WIN_MAIN_KeyUp;
            ss.ResumeLayout(false);
            ss.PerformLayout();
            p_main.ResumeLayout(false);
            p_main.PerformLayout();
            tlp_main.ResumeLayout(false);
            tlp_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nud_port).EndInit();
            ms.ResumeLayout(false);
            ms.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip ss;
        private ToolStripStatusLabel ss_label;
        private Panel p_main;
        private TableLayoutPanel tlp_main;
        private Button b_connect;
        private ToolStripStatusLabel ss_robot;
        private ToolStripStatusLabel ss_controller;
        private Label l_hostname;
        private TextBox t_hostname;
        private TextBox robotInfo;
        private Label ls_console;
        private Label l_port;
        private NumericUpDown nud_port;
        private Label ls_robotInfo;
        private Button b_clearConsole;
        private Label l_status;
        private TextBox robotState;
        private Button b_enable;
        private Button b_disable;
        private TextBox console;
        private Button b_kill;
        private Button b_startCode;
        private MenuStrip ms;
        private ToolStripMenuItem ms_robot;
        private ToolStripMenuItem robot_customPacket;
        private ToolStripMenuItem ms_joystick;
        private ToolStripMenuItem joystick_configure;
        private ToolStripComboBox robot_auton;
        private ToolStripMenuItem joystick_bypass;
        private ToolStripMenuItem joystick_rescan;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem ms_help;
        private ToolStripMenuItem help_about;
    }
}
