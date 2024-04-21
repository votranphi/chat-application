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
    public partial class FileViewForm : Form
    {
        private byte[] buffer;
        private int readBytes;
        private string fileName;
        private string fileExtension;

        public FileViewForm(byte[] buffer, int readBytes, string username, string fileName, string fileExtension)
        {
            this.buffer = buffer;
            this.readBytes = readBytes;
            this.fileName = fileName;
            this.fileExtension = fileExtension;
            InitializeComponent();
            this.Text = $"{username}'s FileViewForm";
        }

        private void FileViewForm_Load(object sender, EventArgs e)
        {
            lblFileName.Text = fileName;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            // download the file to C:\Users\USER_MACHINE_NAME\Downloads
            string path = Environment.GetEnvironmentVariable("TEMP");

            path += "\\..\\..\\..\\Downloads\\";

            string fileNameWithoutExtension = fileName.Replace(fileExtension, "");

            // File.WriteAllBytes($"{path}\\{fileNameWithoutExtension}{fileExtension}", bytes); // non size flexible
            var stream = File.OpenWrite($"{path}\\{fileNameWithoutExtension}{fileExtension}");
            stream.Write(buffer, 0, readBytes); // size flexible

            MessageBox.Show($"File is downloaded to {path}!");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
