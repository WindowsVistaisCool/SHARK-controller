namespace SPRK
{
    public partial class WIN_CameraStream : Form
    {
        private readonly Action onClose;

        public WIN_CameraStream(string winTitle, string url, Action onClose)
        {
            InitializeComponent();

            this.onClose = onClose;
            Text = winTitle;
            try
            {
                camera.Source = new Uri(url);
            }
            catch (Exception) { }
        }

        private void WIN_CameraStream_FormClosing(object sender, FormClosingEventArgs e)
        {
            onClose.Invoke();
        }
    }
}
