using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Client
{
    partial class ClientForm
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
            msgToSend = new TextBox();
            tbReceiver = new TextBox();
            btnLogout = new Button();
            btnCreateGroup = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            sendBtn = new PictureBox();
            statusAndMsg = new RichTextBox();
            pictureBox4 = new PictureBox();
            imageBtn = new PictureBox();
            btnVoice = new PictureBox();
            emojiCB = new ComboBox();
            dgvUser = new DataGridView();
            _username = new DataGridViewTextBoxColumn();
            dgvGroup = new DataGridView();
            groupsName = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sendBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnVoice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvGroup).BeginInit();
            SuspendLayout();
            // 
            // msgToSend
            // 
            msgToSend.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            msgToSend.Location = new Point(462, 594);
            msgToSend.Name = "msgToSend";
            msgToSend.Size = new Size(454, 29);
            msgToSend.TabIndex = 0;
            msgToSend.KeyPress += msgToSend_KeyPress;
            // 
            // tbReceiver
            // 
            tbReceiver.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbReceiver.Location = new Point(272, 19);
            tbReceiver.Name = "tbReceiver";
            tbReceiver.ReadOnly = true;
            tbReceiver.Size = new Size(159, 29);
            tbReceiver.TabIndex = 2;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.IndianRed;
            btnLogout.BackgroundImageLayout = ImageLayout.Stretch;
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogout.Location = new Point(867, 14);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(105, 50);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Log out";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnCreateGroup
            // 
            btnCreateGroup.BackColor = Color.MediumSeaGreen;
            btnCreateGroup.BackgroundImageLayout = ImageLayout.Stretch;
            btnCreateGroup.Cursor = Cursors.Hand;
            btnCreateGroup.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCreateGroup.Location = new Point(702, 14);
            btnCreateGroup.Name = "btnCreateGroup";
            btnCreateGroup.Size = new Size(146, 50);
            btnCreateGroup.TabIndex = 6;
            btnCreateGroup.Text = "Create group";
            btnCreateGroup.TextAlign = ContentAlignment.MiddleLeft;
            btnCreateGroup.UseVisualStyleBackColor = false;
            btnCreateGroup.Click += btnCreateGroup_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.MediumSeaGreen;
            pictureBox1.BackgroundImage = Properties.Resources.createGroup;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(805, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(37, 40);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.IndianRed;
            pictureBox2.BackgroundImage = Properties.Resources.logOut;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(932, 19);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(37, 40);
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // sendBtn
            // 
            sendBtn.BackColor = Color.CornflowerBlue;
            sendBtn.BackgroundImage = Properties.Resources.send_icon2;
            sendBtn.BackgroundImageLayout = ImageLayout.Stretch;
            sendBtn.Cursor = Cursors.Hand;
            sendBtn.Location = new Point(922, 585);
            sendBtn.Name = "sendBtn";
            sendBtn.Size = new Size(50, 50);
            sendBtn.TabIndex = 9;
            sendBtn.TabStop = false;
            sendBtn.Click += sendBtn_Click;
            // 
            // statusAndMsg
            // 
            statusAndMsg.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            statusAndMsg.Location = new Point(272, 70);
            statusAndMsg.Name = "statusAndMsg";
            statusAndMsg.Size = new Size(700, 500);
            statusAndMsg.TabIndex = 10;
            statusAndMsg.Text = "";
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.CornflowerBlue;
            pictureBox4.Location = new Point(272, 579);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(702, 60);
            pictureBox4.TabIndex = 11;
            pictureBox4.TabStop = false;
            // 
            // imageBtn
            // 
            imageBtn.BackColor = Color.CornflowerBlue;
            imageBtn.BackgroundImage = Properties.Resources.photoIcon;
            imageBtn.BackgroundImageLayout = ImageLayout.Zoom;
            imageBtn.Cursor = Cursors.Hand;
            imageBtn.Location = new Point(282, 585);
            imageBtn.Name = "imageBtn";
            imageBtn.Size = new Size(50, 50);
            imageBtn.TabIndex = 12;
            imageBtn.TabStop = false;
            imageBtn.Click += imageBtn_Click;
            // 
            // btnVoice
            // 
            btnVoice.BackColor = Color.CornflowerBlue;
            btnVoice.BackgroundImage = Properties.Resources.voiceIcon;
            btnVoice.BackgroundImageLayout = ImageLayout.Zoom;
            btnVoice.Cursor = Cursors.Hand;
            btnVoice.Location = new Point(350, 585);
            btnVoice.Name = "btnVoice";
            btnVoice.Size = new Size(50, 50);
            btnVoice.TabIndex = 13;
            btnVoice.TabStop = false;
            btnVoice.Click += btnVoice_Click;
            // 
            // emojiCB
            // 
            emojiCB.AllowDrop = true;
            emojiCB.FormattingEnabled = true;
            emojiCB.ItemHeight = 15;
            emojiCB.Items.AddRange(new object[] { "😁", "😂", "\U0001f923", "😅", "😆", "😍", "😘", "\U0001f970", "👍", "❤" });
            emojiCB.Location = new Point(406, 596);
            emojiCB.Name = "emojiCB";
            emojiCB.Size = new Size(50, 23);
            emojiCB.TabIndex = 14;
            emojiCB.SelectedIndexChanged += emojiCB_SelectedIndexChanged;
            // 
            // dgvUser
            // 
            dgvUser.AllowUserToAddRows = false;
            dgvUser.AllowUserToDeleteRows = false;
            dgvUser.AllowUserToResizeColumns = false;
            dgvUser.AllowUserToResizeRows = false;
            dgvUser.BackgroundColor = Color.White;
            dgvUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUser.Columns.AddRange(new DataGridViewColumn[] { _username });
            dgvUser.Location = new Point(12, 19);
            dgvUser.Name = "dgvUser";
            dgvUser.RowTemplate.Height = 25;
            dgvUser.Size = new Size(254, 283);
            dgvUser.TabIndex = 15;
            dgvUser.SelectionChanged += dgvUser_SelectionChanged;
            // 
            // _username
            // 
            _username.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _username.HeaderText = "Username";
            _username.Name = "_username";
            // 
            // dgvGroup
            // 
            dgvGroup.AllowUserToAddRows = false;
            dgvGroup.AllowUserToDeleteRows = false;
            dgvGroup.AllowUserToResizeColumns = false;
            dgvGroup.AllowUserToResizeRows = false;
            dgvGroup.BackgroundColor = Color.White;
            dgvGroup.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGroup.Columns.AddRange(new DataGridViewColumn[] { groupsName });
            dgvGroup.Location = new Point(12, 356);
            dgvGroup.Name = "dgvGroup";
            dgvGroup.RowTemplate.Height = 25;
            dgvGroup.Size = new Size(254, 283);
            dgvGroup.TabIndex = 15;
            dgvGroup.SelectionChanged += dgvGroup_SelectionChanged;
            // 
            // groupsName
            // 
            groupsName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            groupsName.HeaderText = "Group's name";
            groupsName.Name = "groupsName";
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumSeaGreen;
            BackgroundImage = Properties.Resources.form_background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(984, 661);
            Controls.Add(dgvGroup);
            Controls.Add(dgvUser);
            Controls.Add(emojiCB);
            Controls.Add(btnVoice);
            Controls.Add(imageBtn);
            Controls.Add(statusAndMsg);
            Controls.Add(sendBtn);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(btnCreateGroup);
            Controls.Add(btnLogout);
            Controls.Add(tbReceiver);
            Controls.Add(msgToSend);
            Controls.Add(pictureBox4);
            Name = "ClientForm";
            Text = "ClientForm";
            Load += ClientForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)sendBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnVoice).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvGroup).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox msgToSend;
        private TextBox tbReceiver;
        private Button btnLogout;
        private Button btnCreateGroup;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox sendBtn;
        private RichTextBox statusAndMsg;
        private PictureBox pictureBox4;
        private PictureBox imageBtn;
        private PictureBox btnVoice;
        private ComboBox emojiCB;
        private DataGridView dgvUser;
        private DataGridView dgvGroup;
        private DataGridViewTextBoxColumn _username;
        private DataGridViewTextBoxColumn groupsName;
    }
}