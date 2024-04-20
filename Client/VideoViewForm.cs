using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class VideoViewForm : Form
    {
        private byte[] bytes;
        private string fileName;
        private string fileExtension;
        WMPLib.WindowsMediaPlayer Player;

        public VideoViewForm(byte[] bytes, string username, string fileName, string fileExtension)
        {
            this.bytes = bytes;
            this.fileName = fileName;
            this.fileExtension = fileExtension;
            InitializeComponent();
            this.Text = $"{username}'s VideoViewForm";
        }

        private void VideoViewForm_Load(object sender, EventArgs e)
        {
            // download the file to C:\Users\USER_MACHINE_NAME\Downloads
            string path = Environment.GetEnvironmentVariable("TEMP");

            path += "\\..\\..\\..\\Downloads\\";

            string fileNameWithoutExtension = fileName.Replace(fileExtension, "");

            File.WriteAllBytes($"{path}\\tempVideo{fileExtension}", bytes);

            // then play it
            PlayFile($"{path}\\tempVideo{fileExtension}");
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            // download the file to C:\Users\USER_MACHINE_NAME\Downloads
            string path = Environment.GetEnvironmentVariable("TEMP");

            path += "\\..\\..\\..\\Downloads\\";

            string fileNameWithoutExtension = fileName.Replace(fileExtension, "");

            File.WriteAllBytes($"{path}\\{fileNameWithoutExtension}{fileExtension}", bytes);

            MessageBox.Show($"Video is downloaded to {path}!");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PlayFile(string url)
        {
            Player = new WMPLib.WindowsMediaPlayer();
            Player.PlayStateChange +=
                new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
            Player.MediaError +=
                new WMPLib._WMPOCXEvents_MediaErrorEventHandler(Player_MediaError);
            Player.URL = url;
            Player.controls.play();
        }

        private void Player_PlayStateChange(int NewState)
        {
            if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsStopped)
            {
                this.Close();
            }
        }

        private void Player_MediaError(object pMediaObject)
        {
            MessageBox.Show("Cannot play media file.");
            this.Close();
        }
    }
}
