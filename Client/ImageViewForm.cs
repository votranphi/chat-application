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
        private byte[] buffer;
        private string fileName;
        private int readBytes;

        public ImageViewForm(byte[] buffer, int readBytes, string username, string fileName)
        {
            this.buffer = buffer;
            this.readBytes = readBytes;
            this.fileName = fileName;
            InitializeComponent();
            this.Text = $"{username}'s ImageViewForm";
        }

        private void ImageViewForm_Load(object sender, EventArgs e)
        {
            // byte array to image (base64String to image file) then display it to the picturebox
            Bitmap bmp;
            using (var ms = new MemoryStream(buffer))
            {
                bmp = new Bitmap(ms);
            }

            pb.Image = bmp;
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

            MessageBox.Show($"Image is downloaded to {path}\\{fileName}!");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
