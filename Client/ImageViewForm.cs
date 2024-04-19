using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ImageViewForm : Form
    {
        byte[] bytes;

        public ImageViewForm(byte[] bytes, string username)
        {
            this.bytes = bytes;
            InitializeComponent();
            this.Text = $"{username}'s ImageViewForm";
        }

        private void ImageViewForm_Load(object sender, EventArgs e)
        {
            // byte array to image (base64String to image file)
            Bitmap bmp;
            using (var ms = new MemoryStream(bytes))
            {
                bmp = new Bitmap(ms);
            }

            pb.Image = bmp;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            // download the file to a specified directory
        }
    }
}
