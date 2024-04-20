namespace ClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.txtCount = new System.Windows.Forms.TextBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.portInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sendBtn = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.ipInput = new System.Windows.Forms.TextBox();
            this.sendFileBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCount
            // 
            this.txtCount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCount.Location = new System.Drawing.Point(696, 332);
            this.txtCount.Multiline = true;
            this.txtCount.Name = "txtCount";
            this.txtCount.ReadOnly = true;
            this.txtCount.Size = new System.Drawing.Size(94, 24);
            this.txtCount.TabIndex = 32;
            this.txtCount.Text = "0/2000";
            this.txtCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCount.TextChanged += new System.EventHandler(this.txtCount_TextChanged);
            // 
            // connectBtn
            // 
            this.connectBtn.BackColor = System.Drawing.Color.White;
            this.connectBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectBtn.Location = new System.Drawing.Point(676, 14);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(116, 72);
            this.connectBtn.TabIndex = 31;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = false;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // nameInput
            // 
            this.nameInput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameInput.Location = new System.Drawing.Point(424, 62);
            this.nameInput.Multiline = true;
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(136, 27);
            this.nameInput.TabIndex = 30;
            this.nameInput.Text = "Alice";
            this.nameInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(350, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 21);
            this.label3.TabIndex = 29;
            this.label3.Text = "Name";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(16, 355);
            this.richTextBox2.Multiline = false;
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(776, 39);
            this.richTextBox2.TabIndex = 28;
            this.richTextBox2.Text = "";
            this.richTextBox2.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(350, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 21);
            this.label2.TabIndex = 27;
            this.label2.Text = "Port";
            // 
            // portInput
            // 
            this.portInput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portInput.Location = new System.Drawing.Point(424, 12);
            this.portInput.Multiline = true;
            this.portInput.Name = "portInput";
            this.portInput.Size = new System.Drawing.Size(136, 29);
            this.portInput.TabIndex = 26;
            this.portInput.Text = "11000";
            this.portInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 21);
            this.label1.TabIndex = 25;
            this.label1.Text = "Server IP";
            // 
            // sendBtn
            // 
            this.sendBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendBtn.Location = new System.Drawing.Point(526, 400);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(266, 40);
            this.sendBtn.TabIndex = 24;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(16, 105);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(776, 226);
            this.richTextBox1.TabIndex = 22;
            this.richTextBox1.Text = "";
            // 
            // ipInput
            // 
            this.ipInput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipInput.Location = new System.Drawing.Point(94, 12);
            this.ipInput.Multiline = true;
            this.ipInput.Name = "ipInput";
            this.ipInput.Size = new System.Drawing.Size(162, 29);
            this.ipInput.TabIndex = 23;
            this.ipInput.Text = "127.0.0.1";
            this.ipInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sendFileBtn
            // 
            this.sendFileBtn.Image = global::ClientForm.Properties.Resources.data_exchange;
            this.sendFileBtn.Location = new System.Drawing.Point(458, 400);
            this.sendFileBtn.Name = "sendFileBtn";
            this.sendFileBtn.Size = new System.Drawing.Size(53, 40);
            this.sendFileBtn.TabIndex = 33;
            this.sendFileBtn.UseVisualStyleBackColor = true;
            this.sendFileBtn.Click += new System.EventHandler(this.sendFileBtn_Click_1);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 469);
            this.Controls.Add(this.sendFileBtn);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.portInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.ipInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox portInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox ipInput;
        private System.Windows.Forms.Button sendFileBtn;
    }
}

