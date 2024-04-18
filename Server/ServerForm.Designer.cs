namespace Server
{
    partial class ServerForm
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
            label1 = new Label();
            ipInput = new TextBox();
            label2 = new Label();
            portInput = new TextBox();
            listenBtn = new Button();
            statusAndMsg = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 8);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 0;
            label1.Text = "IP Address";
            // 
            // ipInput
            // 
            ipInput.Location = new Point(75, 4);
            ipInput.Name = "ipInput";
            ipInput.Size = new Size(116, 23);
            ipInput.TabIndex = 1;
            ipInput.Text = "127.0.0.1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(198, 8);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 2;
            label2.Text = "Port";
            // 
            // portInput
            // 
            portInput.Location = new Point(233, 4);
            portInput.Name = "portInput";
            portInput.Size = new Size(82, 23);
            portInput.TabIndex = 3;
            portInput.Text = "11000";
            // 
            // listenBtn
            // 
            listenBtn.Location = new Point(321, 5);
            listenBtn.Name = "listenBtn";
            listenBtn.Size = new Size(134, 23);
            listenBtn.TabIndex = 4;
            listenBtn.Text = "Listen";
            listenBtn.UseVisualStyleBackColor = true;
            listenBtn.Click += listenBtn_Click;
            // 
            // statusAndMsg
            // 
            statusAndMsg.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            statusAndMsg.Location = new Point(7, 32);
            statusAndMsg.Name = "statusAndMsg";
            statusAndMsg.Size = new Size(448, 219);
            statusAndMsg.TabIndex = 5;
            statusAndMsg.Text = "";
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(459, 258);
            Controls.Add(statusAndMsg);
            Controls.Add(listenBtn);
            Controls.Add(portInput);
            Controls.Add(label2);
            Controls.Add(ipInput);
            Controls.Add(label1);
            Name = "ServerForm";
            Text = "ServerForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox ipInput;
        private Label label2;
        private TextBox portInput;
        private Button listenBtn;
        private RichTextBox statusAndMsg;
    }
}