using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Client
{
    partial class SignUpForm
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
            tbUsername = new TextBox();
            tbPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            btnSignUp = new Button();
            label6 = new Label();
            label3 = new Label();
            tbPort = new TextBox();
            label5 = new Label();
            tbServerIP = new TextBox();
            label7 = new Label();
            tbPassConf = new TextBox();
            SuspendLayout();
            // 
            // tbUsername
            // 
            tbUsername.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbUsername.Location = new Point(425, 292);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(216, 32);
            tbUsername.TabIndex = 2;
            // 
            // tbPassword
            // 
            tbPassword.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbPassword.Location = new Point(425, 345);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(216, 32);
            tbPassword.TabIndex = 3;
            tbPassword.PasswordChar = '*';
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Image = Properties.Resources.form_background;
            label1.Location = new Point(255, 295);
            label1.Name = "label1";
            label1.Size = new Size(97, 25);
            label1.TabIndex = 2;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Image = Properties.Resources.form_background;
            label2.Location = new Point(255, 348);
            label2.Name = "label2";
            label2.Size = new Size(91, 25);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(486, 407);
            label4.Name = "label4";
            label4.Size = new Size(0, 15);
            label4.TabIndex = 7;
            // 
            // btnSignUp
            // 
            btnSignUp.BackColor = SystemColors.Highlight;
            btnSignUp.Cursor = Cursors.Hand;
            btnSignUp.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnSignUp.Location = new Point(461, 461);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(131, 40);
            btnSignUp.TabIndex = 5;
            btnSignUp.Text = "Sign up";
            btnSignUp.UseVisualStyleBackColor = false;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label6.Image = Properties.Resources.form_background;
            label6.Location = new Point(379, 114);
            label6.Name = "label6";
            label6.Size = new Size(303, 45);
            label6.TabIndex = 10;
            label6.Text = "Create new account";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Image = Properties.Resources.form_background;
            label3.Location = new Point(255, 242);
            label3.Name = "label3";
            label3.Size = new Size(46, 25);
            label3.TabIndex = 12;
            label3.Text = "Port";
            // 
            // tbPort
            // 
            tbPort.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbPort.Location = new Point(425, 239);
            tbPort.Name = "tbPort";
            tbPort.Size = new Size(216, 32);
            tbPort.TabIndex = 1;
            tbPort.Text = "11000";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Image = Properties.Resources.form_background;
            label5.Location = new Point(255, 190);
            label5.Name = "label5";
            label5.Size = new Size(86, 25);
            label5.TabIndex = 14;
            label5.Text = "Server IP";
            // 
            // tbServerIP
            // 
            tbServerIP.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbServerIP.Location = new Point(425, 187);
            tbServerIP.Name = "tbServerIP";
            tbServerIP.Size = new Size(216, 32);
            tbServerIP.TabIndex = 0;
            tbServerIP.Text = "127.0.0.1";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Image = Properties.Resources.form_background;
            label7.Location = new Point(255, 399);
            label7.Name = "label7";
            label7.Size = new Size(164, 25);
            label7.TabIndex = 16;
            label7.Text = "Confirm Password";
            // 
            // tbPassConf
            // 
            tbPassConf.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbPassConf.Location = new Point(425, 396);
            tbPassConf.Name = "tbPassConf";
            tbPassConf.Size = new Size(216, 32);
            tbPassConf.TabIndex = 4;
            tbPassConf.PasswordChar = '*';
            // 
            // SignUpForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.form_background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(984, 661);
            Controls.Add(label7);
            Controls.Add(tbPassConf);
            Controls.Add(label5);
            Controls.Add(tbServerIP);
            Controls.Add(label3);
            Controls.Add(tbPort);
            Controls.Add(label6);
            Controls.Add(btnSignUp);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbPassword);
            Controls.Add(tbUsername);
            MaximumSize = new Size(1000, 700);
            MinimumSize = new Size(1000, 700);
            Name = "SignUpForm";
            Text = "SignUpForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbUsername;
        private TextBox tbPassword;
        private Label label1;
        private Label label2;
        private Label label4;
        private Button btnSignUp;
        private Label label6;
        private Label label3;
        private TextBox tbPort;
        private Label label5;
        private TextBox tbServerIP;
        private Label label7;
        private TextBox tbPassConf;
    }
}
