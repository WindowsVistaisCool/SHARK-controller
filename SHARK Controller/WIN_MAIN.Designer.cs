﻿namespace SPRK
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
            ls_console = new Label();
            l_hostname = new Label();
            l_port = new Label();
            b_connect = new Button();
            b_clearConsole = new Button();
            robotInfo = new TextBox();
            ls_robotInfo = new Label();
            robotState = new TextBox();
            b_disable = new Button();
            b_kill = new Button();
            b_startCode = new Button();
            b_teleop = new Button();
            b_auton = new Button();
            l_status = new Label();
            nud_port = new NumericUpDown();
            cb_hostname = new ComboBox();
            console = new RichTextBox();
            ms = new MenuStrip();
            ms_prefs = new ToolStripMenuItem();
            backgroundPrefs = new ToolStripMenuItem();
            ms_joystick = new ToolStripMenuItem();
            joystick_rescan = new ToolStripMenuItem();
            tss1 = new ToolStripSeparator();
            joystick_bypass = new ToolStripMenuItem();
            joystick_configure = new ToolStripMenuItem();
            ms_cams = new ToolStripMenuItem();
            stream_launch = new ToolStripMenuItem();
            ms_auton = new ToolStripMenuItem();
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
            ss.Size = new Size(846, 33);
            ss.SizingGrip = false;
            ss.TabIndex = 1;
            ss.Text = "S.H.A.R.K. Controller v1.0 - ";
            // 
            // ss_label
            // 
            ss_label.Font = new Font("Segoe UI", 10F);
            ss_label.Margin = new Padding(8, 5, 50, 8);
            ss_label.Name = "ss_label";
            ss_label.Size = new Size(180, 20);
            ss_label.Text = "S.H.A.R.K. Controller vDEV";
            ss_label.Click += help_about_Click;
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
            p_main.BackgroundImageLayout = ImageLayout.Stretch;
            p_main.Controls.Add(tlp_main);
            p_main.Dock = DockStyle.Fill;
            p_main.Location = new Point(0, 25);
            p_main.Name = "p_main";
            p_main.Padding = new Padding(10, 5, 10, 5);
            p_main.Size = new Size(846, 425);
            p_main.TabIndex = 2;
            // 
            // tlp_main
            // 
            tlp_main.AutoSize = true;
            tlp_main.BackColor = Color.Transparent;
            tlp_main.ColumnCount = 6;
            tlp_main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 139F));
            tlp_main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 86F));
            tlp_main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 172F));
            tlp_main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 27F));
            tlp_main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlp_main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 134F));
            tlp_main.Controls.Add(ls_console, 0, 6);
            tlp_main.Controls.Add(l_hostname, 4, 0);
            tlp_main.Controls.Add(l_port, 5, 0);
            tlp_main.Controls.Add(b_connect, 0, 0);
            tlp_main.Controls.Add(b_clearConsole, 5, 6);
            tlp_main.Controls.Add(robotInfo, 4, 4);
            tlp_main.Controls.Add(ls_robotInfo, 4, 3);
            tlp_main.Controls.Add(robotState, 0, 4);
            tlp_main.Controls.Add(b_disable, 2, 5);
            tlp_main.Controls.Add(b_kill, 5, 3);
            tlp_main.Controls.Add(b_startCode, 4, 6);
            tlp_main.Controls.Add(b_teleop, 1, 5);
            tlp_main.Controls.Add(b_auton, 0, 5);
            tlp_main.Controls.Add(l_status, 0, 3);
            tlp_main.Controls.Add(nud_port, 5, 1);
            tlp_main.Controls.Add(cb_hostname, 4, 1);
            tlp_main.Controls.Add(console, 0, 7);
            tlp_main.Dock = DockStyle.Fill;
            tlp_main.Location = new Point(10, 5);
            tlp_main.Name = "tlp_main";
            tlp_main.RowCount = 8;
            tlp_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tlp_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tlp_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 7F));
            tlp_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlp_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tlp_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tlp_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tlp_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tlp_main.Size = new Size(826, 415);
            tlp_main.TabIndex = 0;
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
            // l_hostname
            // 
            l_hostname.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            l_hostname.AutoSize = true;
            l_hostname.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            l_hostname.Location = new Point(427, 14);
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
            l_port.Location = new Point(695, 14);
            l_port.Name = "l_port";
            l_port.Size = new Size(37, 20);
            l_port.TabIndex = 6;
            l_port.Text = "Port";
            // 
            // b_connect
            // 
            b_connect.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlp_main.SetColumnSpan(b_connect, 3);
            b_connect.Font = new Font("Segoe UI", 14.2641506F, FontStyle.Regular, GraphicsUnit.Point, 0);
            b_connect.Location = new Point(3, 3);
            b_connect.Name = "b_connect";
            tlp_main.SetRowSpan(b_connect, 2);
            b_connect.Size = new Size(391, 66);
            b_connect.TabIndex = 2;
            b_connect.Text = "&Connect to Robot";
            b_connect.UseVisualStyleBackColor = true;
            b_connect.Click += ConnectButtonClicked;
            // 
            // b_clearConsole
            // 
            b_clearConsole.Anchor = AnchorStyles.Right;
            b_clearConsole.AutoSize = true;
            b_clearConsole.Location = new Point(724, 229);
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
            robotInfo.BackColor = SystemColors.ActiveCaption;
            robotInfo.BorderStyle = BorderStyle.FixedSingle;
            tlp_main.SetColumnSpan(robotInfo, 2);
            robotInfo.Font = new Font("Segoe UI", 10.18868F);
            robotInfo.Location = new Point(429, 114);
            robotInfo.Margin = new Padding(5);
            robotInfo.Multiline = true;
            robotInfo.Name = "robotInfo";
            robotInfo.ReadOnly = true;
            tlp_main.SetRowSpan(robotInfo, 2);
            robotInfo.ScrollBars = ScrollBars.Vertical;
            robotInfo.Size = new Size(392, 106);
            robotInfo.TabIndex = 9;
            robotInfo.TabStop = false;
            // 
            // ls_robotInfo
            // 
            ls_robotInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ls_robotInfo.AutoSize = true;
            ls_robotInfo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            ls_robotInfo.Location = new Point(427, 89);
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
            tlp_main.SetColumnSpan(robotState, 3);
            robotState.Font = new Font("Segoe UI Black", 14.2641506F, FontStyle.Bold, GraphicsUnit.Point, 0);
            robotState.Location = new Point(3, 112);
            robotState.Name = "robotState";
            robotState.ReadOnly = true;
            robotState.ShortcutsEnabled = false;
            robotState.Size = new Size(391, 36);
            robotState.TabIndex = 12;
            robotState.TabStop = false;
            robotState.Text = "Disconnected";
            robotState.TextAlign = HorizontalAlignment.Center;
            robotState.WordWrap = false;
            robotState.Enter += robotState_Enter;
            // 
            // b_disable
            // 
            b_disable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            b_disable.BackColor = SystemColors.Control;
            b_disable.Enabled = false;
            b_disable.FlatStyle = FlatStyle.Popup;
            b_disable.Font = new Font("Segoe UI", 14.2641506F);
            b_disable.Location = new Point(253, 165);
            b_disable.Margin = new Padding(0, 10, 0, 10);
            b_disable.Name = "b_disable";
            b_disable.Size = new Size(116, 50);
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
            b_kill.Location = new Point(713, 82);
            b_kill.Name = "b_kill";
            b_kill.Size = new Size(110, 24);
            b_kill.TabIndex = 15;
            b_kill.Text = "&Kill Robot Code";
            b_kill.UseVisualStyleBackColor = true;
            b_kill.Click += b_kill_Click;
            // 
            // b_startCode
            // 
            b_startCode.Anchor = AnchorStyles.Left;
            b_startCode.AutoSize = true;
            b_startCode.Location = new Point(427, 229);
            b_startCode.Name = "b_startCode";
            b_startCode.Size = new Size(155, 27);
            b_startCode.TabIndex = 16;
            b_startCode.Text = "Start Robot Code (SSH)";
            b_startCode.UseVisualStyleBackColor = true;
            b_startCode.Visible = false;
            b_startCode.Click += b_startCode_Click;
            // 
            // b_teleop
            // 
            b_teleop.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            b_teleop.BackColor = SystemColors.Control;
            b_teleop.Enabled = false;
            b_teleop.FlatStyle = FlatStyle.Popup;
            b_teleop.Font = new Font("Segoe UI", 14.2641506F);
            b_teleop.Location = new Point(139, 165);
            b_teleop.Margin = new Padding(0, 10, 0, 10);
            b_teleop.Name = "b_teleop";
            b_teleop.Size = new Size(85, 50);
            b_teleop.TabIndex = 13;
            b_teleop.Text = "Teleop";
            b_teleop.UseVisualStyleBackColor = false;
            b_teleop.Visible = false;
            b_teleop.Click += b_teleop_Click;
            // 
            // b_auton
            // 
            b_auton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            b_auton.Enabled = false;
            b_auton.FlatStyle = FlatStyle.Popup;
            b_auton.Font = new Font("Segoe UI", 14.2641506F);
            b_auton.Location = new Point(54, 165);
            b_auton.Margin = new Padding(0, 10, 0, 10);
            b_auton.Name = "b_auton";
            b_auton.Size = new Size(85, 50);
            b_auton.TabIndex = 17;
            b_auton.Text = "Auto";
            b_auton.UseVisualStyleBackColor = false;
            b_auton.Visible = false;
            b_auton.Click += b_auton_Click;
            // 
            // l_status
            // 
            l_status.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            l_status.AutoSize = true;
            l_status.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            l_status.Location = new Point(3, 89);
            l_status.Name = "l_status";
            l_status.Size = new Size(95, 20);
            l_status.TabIndex = 11;
            l_status.Text = "Robot Status";
            // 
            // nud_port
            // 
            nud_port.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nud_port.Location = new Point(695, 40);
            nud_port.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nud_port.Name = "nud_port";
            nud_port.Size = new Size(128, 25);
            nud_port.TabIndex = 7;
            nud_port.Value = new decimal(new int[] { 8008, 0, 0, 0 });
            // 
            // cb_hostname
            // 
            cb_hostname.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cb_hostname.FormattingEnabled = true;
            cb_hostname.Location = new Point(427, 40);
            cb_hostname.Name = "cb_hostname";
            cb_hostname.Size = new Size(262, 25);
            cb_hostname.TabIndex = 18;
            // 
            // console
            // 
            console.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            console.BackColor = Color.FromArgb(28, 28, 28);
            tlp_main.SetColumnSpan(console, 6);
            console.Font = new Font("Cascadia Code", 10.15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            console.ForeColor = SystemColors.InactiveBorder;
            console.Location = new Point(3, 264);
            console.Name = "console";
            console.ReadOnly = true;
            console.ScrollBars = RichTextBoxScrollBars.Vertical;
            console.Size = new Size(820, 148);
            console.TabIndex = 19;
            console.Text = "";
            // 
            // ms
            // 
            ms.ImageScalingSize = new Size(18, 18);
            ms.Items.AddRange(new ToolStripItem[] { ms_prefs, ms_joystick, ms_cams, ms_auton, ms_help });
            ms.Location = new Point(0, 0);
            ms.Name = "ms";
            ms.Size = new Size(846, 25);
            ms.TabIndex = 1;
            ms.Text = "menuStrip1";
            // 
            // ms_prefs
            // 
            ms_prefs.DropDownItems.AddRange(new ToolStripItem[] { backgroundPrefs });
            ms_prefs.Name = "ms_prefs";
            ms_prefs.Size = new Size(88, 21);
            ms_prefs.Text = "&Preferences";
            ms_prefs.Visible = false;
            // 
            // backgroundPrefs
            // 
            backgroundPrefs.CheckOnClick = true;
            backgroundPrefs.Name = "backgroundPrefs";
            backgroundPrefs.Size = new Size(217, 24);
            backgroundPrefs.Text = "&Use Background Image";
            backgroundPrefs.CheckedChanged += backgroundPrefs_CheckedChanged;
            // 
            // ms_joystick
            // 
            ms_joystick.DropDownItems.AddRange(new ToolStripItem[] { joystick_rescan, tss1, joystick_bypass, joystick_configure });
            ms_joystick.Name = "ms_joystick";
            ms_joystick.Size = new Size(64, 21);
            ms_joystick.Text = "&Joystick";
            // 
            // joystick_rescan
            // 
            joystick_rescan.Name = "joystick_rescan";
            joystick_rescan.ShortcutKeys = Keys.F1;
            joystick_rescan.Size = new Size(214, 24);
            joystick_rescan.Text = "&Rescan";
            joystick_rescan.Click += ss_controller_Click;
            // 
            // tss1
            // 
            tss1.Name = "tss1";
            tss1.Size = new Size(211, 6);
            // 
            // joystick_bypass
            // 
            joystick_bypass.CheckOnClick = true;
            joystick_bypass.Name = "joystick_bypass";
            joystick_bypass.ShortcutKeys = Keys.Control | Keys.B;
            joystick_bypass.Size = new Size(214, 24);
            joystick_bypass.Text = "&Bypass Joystick";
            joystick_bypass.Click += joystick_bypass_Click;
            // 
            // joystick_configure
            // 
            joystick_configure.Enabled = false;
            joystick_configure.Name = "joystick_configure";
            joystick_configure.Size = new Size(214, 24);
            joystick_configure.Text = "&Configure/Test";
            joystick_configure.Visible = false;
            // 
            // ms_cams
            // 
            ms_cams.DropDownItems.AddRange(new ToolStripItem[] { stream_launch });
            ms_cams.Name = "ms_cams";
            ms_cams.Size = new Size(71, 21);
            ms_cams.Text = "C&ameras";
            ms_cams.Visible = false;
            // 
            // stream_launch
            // 
            stream_launch.Name = "stream_launch";
            stream_launch.Size = new Size(198, 24);
            stream_launch.Text = "&Launch Stream";
            stream_launch.Click += vision_launch_Click;
            // 
            // ms_auton
            // 
            ms_auton.DropDownItems.AddRange(new ToolStripItem[] { robot_auton });
            ms_auton.Enabled = false;
            ms_auton.Name = "ms_auton";
            ms_auton.Size = new Size(132, 21);
            ms_auton.Text = "&Select Autonomous";
            // 
            // robot_auton
            // 
            robot_auton.DropDownStyle = ComboBoxStyle.DropDownList;
            robot_auton.Items.AddRange(new object[] { "Autonomous 1", "Autonomous 2" });
            robot_auton.Name = "robot_auton";
            robot_auton.Size = new Size(121, 25);
            robot_auton.SelectedIndexChanged += robot_auton_TextUpdate;
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
            help_about.Size = new Size(117, 24);
            help_about.Text = "&About";
            help_about.Click += help_about_Click;
            // 
            // WIN_MAIN
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(846, 483);
            Controls.Add(p_main);
            Controls.Add(ms);
            Controls.Add(ss);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MainMenuStrip = ms;
            MinimumSize = new Size(862, 524);
            Name = "WIN_MAIN";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "S.P.R.K. Controller";
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
        private TextBox robotInfo;
        private Label ls_console;
        private Label l_port;
        private NumericUpDown nud_port;
        private Label ls_robotInfo;
        private Button b_clearConsole;
        private Label l_status;
        private TextBox robotState;
        private Button b_teleop;
        private Button b_disable;
        private Button b_kill;
        private Button b_startCode;
        private MenuStrip ms;
        private ToolStripMenuItem ms_auton;
        private ToolStripMenuItem ms_joystick;
        private ToolStripMenuItem joystick_configure;
        private ToolStripComboBox robot_auton;
        private ToolStripMenuItem joystick_bypass;
        private ToolStripMenuItem joystick_rescan;
        private ToolStripSeparator tss1;
        private ToolStripMenuItem ms_help;
        private ToolStripMenuItem help_about;
        private Button b_auton;
        private ComboBox cb_hostname;
        private RichTextBox console;
        private ToolStripMenuItem ms_prefs;
        private ToolStripMenuItem backgroundPrefs;
        private ToolStripMenuItem ms_cams;
        private ToolStripMenuItem stream_launch;
    }
}
