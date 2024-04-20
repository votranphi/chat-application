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
using MediaPlayer;
using WMPLib;

namespace Client
{
    public partial class VideoViewForm : Form
    {
        private byte[] bytes;
        private string fileName;
        private string fileExtension;

        public VideoViewForm(byte[] bytes, string username, string fileName, string fileExtension)
        {
            this.bytes = bytes;
            this.fileName = fileName;
            this.fileExtension = fileExtension;
            InitializeComponent();
            this.Text = $"{username}'s ImageViewForm";
        }

        private void VideoViewForm_Load(object sender, EventArgs e)
        {
            // play the video in here
            
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
    }
}
