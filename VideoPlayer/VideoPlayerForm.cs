using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoPlayer
{
    public partial class VideoPlayerForm : Form
    {
        private byte[] buffer;
        private int readBytes;
        private string fileName;
        private string fileExtension;
        private string path;

        public VideoPlayerForm(byte[] buffer, int readBytes, string username, string fileName, string fileExtension)
        {
            this.buffer = buffer;
            this.readBytes = readBytes;
            this.fileName = fileName;
            this.fileExtension = fileExtension;
            InitializeComponent();
            this.Text = $"{username}'s VideoViewForm";
        }

        private void VideoPlayer_Load(object sender, EventArgs e)
        {
            // download the file to C:\Users\USER_MACHINE_NAME\Downloads
            path = Environment.GetEnvironmentVariable("TEMP");

            // Example: path = "C:\Users\ASUS\AppData\Local\Temp"
            // remove the \Appdata, \Local, \Temp
            path = path.Replace("\\AppData", "");
            path = path.Replace("\\Local", "");
            path = path.Replace("\\Temp", "");

            // go to Downloads folder
            path += "\\Downloads";

            // write the file to "tempVideo.fileExtension" in Downloads folder
            var stream = File.OpenWrite($"{path}\\tempVideo{fileExtension}");
            stream.Write(buffer, 0, readBytes); // size flexible
            stream.Close();

            // then play it
            axWindowsMediaPlayer1.URL = $"{path}\\tempVideo{fileExtension}";
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            // copy the tempVideo to the correct file name if user download it
            File.Copy($"{path}\\tempVideo{fileExtension}", $"{path}\\{fileName}");

            MessageBox.Show($"Video is downloaded to {path}\\{fileName}!");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // delete the tempVideo
            File.Delete($"{path}\\tempVideo{fileExtension}");
            this.Close();
        }
    }
}
