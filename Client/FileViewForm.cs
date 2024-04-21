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

        public FileViewForm(byte[] buffer, int readBytes, string username, string fileName)
        {
            this.buffer = buffer;
            this.readBytes = readBytes;
            this.fileName = fileName;
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

            // Example: path = "C:\Users\ASUS\AppData\Local\Temp"
            // remove the \Appdata, \Local, \Temp
            path = path.Replace("\\AppData", "");
            path = path.Replace("\\Local", "");
            path = path.Replace("\\Temp", "");

            // go to Downloads folder
            path += "\\Downloads";

            // write the byte array to file
            var stream = File.OpenWrite($"{path}\\{fileName}");
            stream.Write(buffer, 0, readBytes); // size flexible
            stream.Close();

            MessageBox.Show($"File is downloaded to {path}\\{fileName}!");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
