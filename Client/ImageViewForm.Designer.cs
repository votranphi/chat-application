using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Client
{
    partial class ImageViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pb = new PictureBox();
            btnDownload = new Button();
            btnClose = new Button();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pb
            // 
            pb.Location = new Point(0, 0);
            pb.Name = "pb";
            pb.Size = new Size(584, 482);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.TabIndex = 0;
            pb.TabStop = false;
            // 
            // btnDownload
            // 
            btnDownload.BackColor = Color.FromArgb(0, 192, 0);
            btnDownload.BackgroundImageLayout = ImageLayout.Center;
            btnDownload.Cursor = Cursors.Hand;
            btnDownload.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDownload.Location = new Point(86, 499);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(130, 50);
            btnDownload.TabIndex = 0;
            btnDownload.Text = "Download";
            btnDownload.TextAlign = ContentAlignment.MiddleLeft;
            btnDownload.UseVisualStyleBackColor = false;
            btnDownload.Click += btnDownload_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Red;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.Location = new Point(367, 499);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(130, 50);
            btnClose.TabIndex = 1;
            btnClose.Text = "      Close";
            btnClose.TextAlign = ContentAlignment.MiddleLeft;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(0, 192, 0);
            pictureBox2.BackgroundImage = Properties.Resources.Download;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(168, 505);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(42, 39);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Red;
            pictureBox3.BackgroundImage = Properties.Resources.closeIcon;
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(451, 504);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(42, 39);
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            // 
            // ImageViewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.form_background;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(584, 561);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(btnClose);
            Controls.Add(btnDownload);
            Controls.Add(pb);
            MaximumSize = new Size(600, 600);
            MinimumSize = new Size(600, 600);
            Name = "ImageViewForm";
            Text = "ImageViewForm";
            Load += ImageViewForm_Load;
            ((System.ComponentModel.ISupportInitialize)pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pb;
        private Button btnDownload;
        private Button btnClose;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
    }
}