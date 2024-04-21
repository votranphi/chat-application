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
    public partial class ImageViewForm : Form
    {
        private byte[] bytes;
        private string fileName;
        private string fileExtension;
        private int readBytes;

        public ImageViewForm(byte[] bytes, int readBytes, string username, string fileName, string fileExtension)
        {
            this.bytes = bytes;
            this.readBytes = readBytes;
            this.fileName = fileName;
            this.fileExtension = fileExtension;
            InitializeComponent();
            this.Text = $"{username}'s ImageViewForm";
        }

        private void ImageViewForm_Load(object sender, EventArgs e)
        {
            // byte array to image (base64String to image file) then display it to the picturebox
            Bitmap bmp;
            using (var ms = new MemoryStream(bytes))
            {
                bmp = new Bitmap(ms);
            }

            pb.Image = bmp;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            // download the file to C:\Users\USER_MACHINE_NAME\Downloads
            string path = Environment.GetEnvironmentVariable("TEMP");

            path += "\\..\\..\\..\\Downloads\\";

            string fileNameWithoutExtension = fileName.Replace(fileExtension, "");

            // File.WriteAllBytes($"{path}\\{fileNameWithoutExtension}{fileExtension}", bytes); // non size flexible
            var stream = File.OpenWrite($"{path}\\{fileNameWithoutExtension}{fileExtension}");
            stream.Write(bytes, 0, readBytes); // size flexible

            MessageBox.Show($"Image is downloaded to {path}!");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
