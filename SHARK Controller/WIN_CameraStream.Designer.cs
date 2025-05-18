using Microsoft.Web.WebView2.WinForms;

namespace SHARK_Controller
{
    partial class WIN_CameraStream
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WIN_CameraStream));
            camera = new WebView2();
            ((System.ComponentModel.ISupportInitialize)camera).BeginInit();
            SuspendLayout();
            // 
            // camera
            // 
            camera.AllowExternalDrop = true;
            camera.CreationProperties = null;
            camera.DefaultBackgroundColor = Color.White;
            camera.Dock = DockStyle.Fill;
            camera.Enabled = false;
            camera.Location = new Point(0, 0);
            camera.MinimumSize = new Size(20, 20);
            camera.Name = "camera";
            camera.Size = new Size(1008, 727);
            camera.TabIndex = 1;
            camera.ZoomFactor = 1D;
            // 
            // WIN_CameraStream
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 727);
            Controls.Add(camera);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "WIN_CameraStream";
            StartPosition = FormStartPosition.CenterParent;
            Text = "WIN_CameraStream";
            FormClosing += WIN_CameraStream_FormClosing;
            ((System.ComponentModel.ISupportInitialize)camera).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private WebView2 camera;
    }
}