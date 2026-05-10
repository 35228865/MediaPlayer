using System;
using System.Drawing;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class frmMediaPlayer : Form
    {
        public frmMediaPlayer()
        {
            InitializeComponent();
            ApplyUIAndFoolProofing();
        }

        private void ApplyUIAndFoolProofing()
        {
            wmpVideo.uiMode = "none";

            btnPlay.Enabled = false;
            btnPause.Enabled = false;
            button4.Enabled = false;

            this.BackColor = Color.FromArgb(30, 30, 30); 
            palButton.BackColor = Color.FromArgb(45, 45, 48); 

            Button[] allButtons = { btnBrowser, btnPlay, btnPause, button4 };
            foreach (Button btn in allButtons)
            {
                btn.FlatStyle = FlatStyle.Flat;                 
                btn.FlatAppearance.BorderSize = 0;              
                btn.BackColor = Color.FromArgb(0, 122, 204);  
                btn.ForeColor = Color.White;                   
                btn.Font = new Font("微軟正黑體", 12F, FontStyle.Bold); 
                btn.Cursor = Cursors.Hand;                      
            }

            button4.Text = "停止";
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
           
            ofd.Filter = "Video files (*.wmv;*.mp4;*.avi)|*.wmv;*.mp4;*.avi|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                
                wmpVideo.settings.autoStart = false;
                wmpVideo.URL = ofd.FileName;

                btnPlay.Enabled = true;
                btnPause.Enabled = true;
                button4.Enabled = true;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(wmpVideo.URL))
            {
                wmpVideo.Ctlcontrols.play();
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(wmpVideo.URL))
            {
                wmpVideo.Ctlcontrols.pause();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(wmpVideo.URL))
            {
                wmpVideo.Ctlcontrols.stop();
            }
        }
    }
}