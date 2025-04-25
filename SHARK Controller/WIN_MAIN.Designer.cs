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
            clearConsole = new Button();
            joystickConsole = new TextBox();
            ls_joystickConsole = new Label();
            ss.SuspendLayout();
            p_main.SuspendLayout();
            tlp_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_port).BeginInit();
            SuspendLayout();
            // 
            // ss
            // 
            ss.ImageScalingSize = new Size(18, 18);
            ss.Items.AddRange(new ToolStripItem[] { ss_label, ss_robot, ss_controller });
            ss.Location = new Point(0, 466);
            ss.Name = "ss";
            ss.Size = new Size(724, 33);
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
            p_main.Location = new Point(0, 0);
            p_main.Name = "p_main";
            p_main.Padding = new Padding(10, 10, 10, 5);
            p_main.Size = new Size(724, 466);
            p_main.TabIndex = 2;
            // 
            // tlp_main
            // 
            tlp_main.ColumnCount = 5;
            tlp_main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 86F));
            tlp_main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 159F));
            tlp_main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 225F));
            tlp_main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 127F));
            tlp_main.Controls.Add(console, 0, 6);
            tlp_main.Controls.Add(ls_console, 0, 5);
            tlp_main.Controls.Add(t_hostname, 3, 1);
            tlp_main.Controls.Add(l_hostname, 3, 0);
            tlp_main.Controls.Add(l_port, 4, 0);
            tlp_main.Controls.Add(nud_port, 4, 1);
            tlp_main.Controls.Add(b_connect, 0, 0);
            tlp_main.Controls.Add(clearConsole, 4, 5);
            tlp_main.Controls.Add(joystickConsole, 0, 4);
            tlp_main.Controls.Add(ls_joystickConsole, 0, 3);
            tlp_main.Dock = DockStyle.Fill;
            tlp_main.Location = new Point(10, 10);
            tlp_main.Name = "tlp_main";
            tlp_main.RowCount = 7;
            tlp_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tlp_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
            tlp_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 7F));
            tlp_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tlp_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 111F));
            tlp_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tlp_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            tlp_main.Size = new Size(704, 451);
            tlp_main.TabIndex = 0;
            // 
            // console
            // 
            console.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlp_main.SetColumnSpan(console, 5);
            console.Font = new Font("Segoe UI", 10.18868F);
            console.Location = new Point(5, 265);
            console.Margin = new Padding(5);
            console.Multiline = true;
            console.Name = "console";
            console.ReadOnly = true;
            console.ScrollBars = ScrollBars.Vertical;
            console.Size = new Size(694, 181);
            console.TabIndex = 0;
            console.TabStop = false;
            console.Text = "\r\n";
            // 
            // ls_console
            // 
            ls_console.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ls_console.AutoSize = true;
            tlp_main.SetColumnSpan(ls_console, 2);
            ls_console.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            ls_console.Location = new Point(3, 237);
            ls_console.Name = "ls_console";
            ls_console.Size = new Size(71, 23);
            ls_console.TabIndex = 1;
            ls_console.Text = "Console";
            // 
            // t_hostname
            // 
            t_hostname.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            t_hostname.Location = new Point(355, 43);
            t_hostname.Name = "t_hostname";
            t_hostname.Size = new Size(219, 25);
            t_hostname.TabIndex = 4;
            t_hostname.Text = "QuackStation";
            // 
            // l_hostname
            // 
            l_hostname.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            l_hostname.AutoSize = true;
            l_hostname.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            l_hostname.Location = new Point(355, 11);
            l_hostname.Name = "l_hostname";
            l_hostname.Size = new Size(111, 23);
            l_hostname.TabIndex = 5;
            l_hostname.Text = "Hostname/IP";
            // 
            // l_port
            // 
            l_port.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            l_port.AutoSize = true;
            l_port.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            l_port.Location = new Point(580, 11);
            l_port.Name = "l_port";
            l_port.Size = new Size(41, 23);
            l_port.TabIndex = 6;
            l_port.Text = "Port";
            // 
            // nud_port
            // 
            nud_port.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nud_port.Location = new Point(580, 43);
            nud_port.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nud_port.Name = "nud_port";
            nud_port.Size = new Size(121, 25);
            nud_port.TabIndex = 7;
            nud_port.Value = new decimal(new int[] { 8008, 0, 0, 0 });
            // 
            // b_connect
            // 
            b_connect.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlp_main.SetColumnSpan(b_connect, 2);
            b_connect.Font = new Font("Segoe UI", 16.3018875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            b_connect.Location = new Point(3, 3);
            b_connect.Name = "b_connect";
            tlp_main.SetRowSpan(b_connect, 2);
            b_connect.Size = new Size(239, 71);
            b_connect.TabIndex = 2;
            b_connect.Text = "Connect to Robot";
            b_connect.UseVisualStyleBackColor = true;
            b_connect.Click += connect_Click;
            // 
            // clearConsole
            // 
            clearConsole.Anchor = AnchorStyles.Right;
            clearConsole.AutoSize = true;
            clearConsole.Location = new Point(602, 227);
            clearConsole.Name = "clearConsole";
            clearConsole.Size = new Size(99, 27);
            clearConsole.TabIndex = 10;
            clearConsole.Text = "Clear Console";
            clearConsole.UseVisualStyleBackColor = true;
            clearConsole.Click += clearConsole_Click;
            // 
            // joystickConsole
            // 
            joystickConsole.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlp_main.SetColumnSpan(joystickConsole, 5);
            joystickConsole.Font = new Font("Segoe UI", 10.18868F);
            joystickConsole.Location = new Point(5, 116);
            joystickConsole.Margin = new Padding(5);
            joystickConsole.Multiline = true;
            joystickConsole.Name = "joystickConsole";
            joystickConsole.ReadOnly = true;
            joystickConsole.ScrollBars = ScrollBars.Vertical;
            joystickConsole.Size = new Size(694, 101);
            joystickConsole.TabIndex = 9;
            joystickConsole.TabStop = false;
            joystickConsole.Text = "Joystick disabled.";
            // 
            // ls_joystickConsole
            // 
            ls_joystickConsole.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ls_joystickConsole.AutoSize = true;
            tlp_main.SetColumnSpan(ls_joystickConsole, 2);
            ls_joystickConsole.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            ls_joystickConsole.Location = new Point(3, 88);
            ls_joystickConsole.Name = "ls_joystickConsole";
            ls_joystickConsole.Size = new Size(116, 23);
            ls_joystickConsole.TabIndex = 8;
            ls_joystickConsole.Text = "Joystick Input";
            // 
            // WIN_MAIN
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(724, 499);
            Controls.Add(p_main);
            Controls.Add(ss);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "WIN_MAIN";
            StartPosition = FormStartPosition.CenterParent;
            Text = "S.H.A.R.K. Controller";
            FormClosing += WIN_MAIN_FormClosing;
            ss.ResumeLayout(false);
            ss.PerformLayout();
            p_main.ResumeLayout(false);
            tlp_main.ResumeLayout(false);
            tlp_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nud_port).EndInit();
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
        private TextBox joystickConsole;
        private Label ls_console;
        private Label l_port;
        private NumericUpDown nud_port;
        private Label ls_joystickConsole;
        private Button clearConsole;
        private TextBox console;
    }
}
