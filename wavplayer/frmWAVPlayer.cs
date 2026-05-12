using System;
using System.Media;
using System.Windows.Forms;

namespace WAVPlayer
{
    public partial class frmWAVPlayer : Form
    {
        // null 表示目前沒有在播放
        private SoundPlayer player = null;

        public frmWAVPlayer()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ofdWAVFile.Filter = "WAV Files(*.wav)|*.wav";
            if (ofdWAVFile.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = ofdWAVFile.FileName;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPath.Text)) return;

            player?.Stop();                          // 停掉舊的
            player = new SoundPlayer(txtPath.Text);  // 建立新的
            player.Load();
            player.Play();                           // 播放一次
        }

        private void btnLoop_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPath.Text)) return;

            player?.Stop();                          // 停掉舊的
            player = new SoundPlayer(txtPath.Text);  // 建立新的
            player.Load();
            player.PlayLooping();                    // 重複播放
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            player?.Stop();   // 停止當前正在播放的實例
            player = null;
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmWAVPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show(
                "確定要關閉應用程式嗎？", "關閉確認",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}