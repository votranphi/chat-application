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
            connectBtn = new Button();
            usernameInput = new TextBox();
            label3 = new Label();
            portInput = new TextBox();
            ipInput = new TextBox();
            label2 = new Label();
            label1 = new Label();
            imageBtn = new Button();
            emojiCB = new ComboBox();
            SuspendLayout();
            // 
            // sendBtn
            // 
            sendBtn.Enabled = false;
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
            msgToSend.TextChanged += msgToSend_TextChanged;
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
            // connectBtn
            // 
            connectBtn.Location = new Point(475, 8);
            connectBtn.Name = "connectBtn";
            connectBtn.Size = new Size(112, 23);
            connectBtn.TabIndex = 16;
            connectBtn.Text = "Connect";
            connectBtn.UseVisualStyleBackColor = true;
            connectBtn.TextChanged += connectBtn_TextChanged;
            connectBtn.Click += connectBtn_Click;
            // 
            // usernameInput
            // 
            usernameInput.Location = new Point(369, 7);
            usernameInput.Name = "usernameInput";
            usernameInput.Size = new Size(100, 23);
            usernameInput.TabIndex = 15;
            usernameInput.Text = "Alice";
            usernameInput.TextChanged += usernameInput_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(303, 10);
            label3.Name = "label3";
            label3.Size = new Size(110, 15);
            label3.TabIndex = 14;
            label3.Text = "Username or Group";
            // 
            // portInput
            // 
            portInput.Location = new Point(235, 7);
            portInput.Name = "portInput";
            portInput.Size = new Size(62, 23);
            portInput.TabIndex = 13;
            portInput.Text = "11000";
            portInput.TextChanged += portInput_TextChanged;
            // 
            // ipInput
            // 
            ipInput.Location = new Point(74, 7);
            ipInput.Name = "ipInput";
            ipInput.Size = new Size(120, 23);
            ipInput.TabIndex = 12;
            ipInput.Text = "127.0.0.1";
            ipInput.TextChanged += ipInput_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(200, 10);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 11;
            label2.Text = "Port";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 10);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 10;
            label1.Text = "IP Address";
            // 
            // imageBtn
            // 
            imageBtn.Enabled = false;
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
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(593, 345);
            Controls.Add(emojiCB);
            Controls.Add(imageBtn);
            Controls.Add(sendBtn);
            Controls.Add(msgToSend);
            Controls.Add(statusAndMsg);
            Controls.Add(connectBtn);
            Controls.Add(usernameInput);
            Controls.Add(label3);
            Controls.Add(portInput);
            Controls.Add(ipInput);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ClientForm";
            Text = "ClientForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button sendBtn;
        private RichTextBox msgToSend;
        private RichTextBox statusAndMsg;
        private Button connectBtn;
        private TextBox usernameInput;
        private Label label3;
        private TextBox portInput;
        private TextBox ipInput;
        private Label label2;
        private Label label1;
        private Button imageBtn;
        private ComboBox emojiCB;
    }
}