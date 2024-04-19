namespace Client
{
    partial class ClientForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            sendBtn = new Button();
            msgToSend = new RichTextBox();
            statusAndMsg = new RichTextBox();
            btnLogout = new Button();
            tbReceiver = new TextBox();
            label3 = new Label();
            imageBtn = new Button();
            emojiCB = new ComboBox();
            btnCreateGroup = new Button();
            SuspendLayout();
            // 
            // sendBtn
            // 
            sendBtn.Location = new Point(512, 317);
            sendBtn.Name = "sendBtn";
            sendBtn.Size = new Size(75, 23);
            sendBtn.TabIndex = 19;
            sendBtn.Text = "Send";
            sendBtn.UseVisualStyleBackColor = true;
            sendBtn.Click += sendBtn_Click;
            // 
            // msgToSend
            // 
            msgToSend.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            msgToSend.Location = new Point(8, 317);
            msgToSend.Multiline = false;
            msgToSend.Name = "msgToSend";
            msgToSend.Size = new Size(371, 23);
            msgToSend.TabIndex = 18;
            msgToSend.Text = "";
            msgToSend.KeyPress += msgToSend_KeyPress;
            // 
            // statusAndMsg
            // 
            statusAndMsg.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            statusAndMsg.Location = new Point(8, 36);
            statusAndMsg.Name = "statusAndMsg";
            statusAndMsg.Size = new Size(579, 275);
            statusAndMsg.TabIndex = 17;
            statusAndMsg.Text = "";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(475, 8);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(112, 23);
            btnLogout.TabIndex = 16;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // tbReceiver
            // 
            tbReceiver.Location = new Point(62, 8);
            tbReceiver.Name = "tbReceiver";
            tbReceiver.Size = new Size(100, 23);
            tbReceiver.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 12);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 14;
            label3.Text = "Send to:";
            // 
            // imageBtn
            // 
            imageBtn.Location = new Point(431, 317);
            imageBtn.Name = "imageBtn";
            imageBtn.Size = new Size(75, 23);
            imageBtn.TabIndex = 21;
            imageBtn.Text = "Image";
            imageBtn.UseVisualStyleBackColor = true;
            imageBtn.Click += imageBtn_Click;
            // 
            // emojiCB
            // 
            emojiCB.FormattingEnabled = true;
            emojiCB.Items.AddRange(new object[] { "😁", "😂", "\U0001f923", "😅", "😆", "😍", "😘", "\U0001f970", "👍", "❤" });
            emojiCB.Location = new Point(385, 317);
            emojiCB.Name = "emojiCB";
            emojiCB.Size = new Size(40, 23);
            emojiCB.TabIndex = 22;
            emojiCB.SelectedIndexChanged += emojiCB_SelectedIndexChanged;
            // 
            // btnCreateGroup
            // 
            btnCreateGroup.Location = new Point(376, 8);
            btnCreateGroup.Name = "btnCreateGroup";
            btnCreateGroup.Size = new Size(93, 23);
            btnCreateGroup.TabIndex = 23;
            btnCreateGroup.Text = "Create Group";
            btnCreateGroup.UseVisualStyleBackColor = true;
            btnCreateGroup.Click += btnCreateGroup_Click;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(593, 345);
            Controls.Add(btnCreateGroup);
            Controls.Add(emojiCB);
            Controls.Add(imageBtn);
            Controls.Add(sendBtn);
            Controls.Add(msgToSend);
            Controls.Add(statusAndMsg);
            Controls.Add(btnLogout);
            Controls.Add(tbReceiver);
            Controls.Add(label3);
            Name = "ClientForm";
            Text = "ClientForm";
            Load += ClientForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button sendBtn;
        private RichTextBox msgToSend;
        private RichTextBox statusAndMsg;
        private Button btnLogout;
        private TextBox tbReceiver;
        private Label label3;
        private Button imageBtn;
        private ComboBox emojiCB;
        private Button btnCreateGroup;
    }
}