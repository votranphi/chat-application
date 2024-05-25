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
            label7 = new Label();
            tbPassConf = new TextBox();
            lblLogin = new Label();
            SuspendLayout();
            // 
            // tbUsername
            // 
            tbUsername.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbUsername.Location = new Point(427, 227);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(216, 32);
            tbUsername.TabIndex = 2;
            // 
            // tbPassword
            // 
            tbPassword.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbPassword.Location = new Point(427, 280);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new Size(216, 32);
            tbPassword.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Image = Properties.Resources.form_background;
            label1.Location = new Point(257, 230);
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
            label2.Location = new Point(257, 283);
            label2.Name = "label2";
            label2.Size = new Size(91, 25);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(488, 342);
            label4.Name = "label4";
            label4.Size = new Size(0, 15);
            label4.TabIndex = 7;
            // 
            // btnSignUp
            // 
            btnSignUp.BackColor = SystemColors.Highlight;
            btnSignUp.Cursor = Cursors.Hand;
            btnSignUp.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnSignUp.Location = new Point(463, 396);
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
            label6.Location = new Point(378, 157);
            label6.Name = "label6";
            label6.Size = new Size(303, 45);
            label6.TabIndex = 10;
            label6.Text = "Create new account";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Image = Properties.Resources.form_background;
            label7.Location = new Point(257, 334);
            label7.Name = "label7";
            label7.Size = new Size(164, 25);
            label7.TabIndex = 16;
            label7.Text = "Confirm Password";
            // 
            // tbPassConf
            // 
            tbPassConf.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbPassConf.Location = new Point(427, 331);
            tbPassConf.Name = "tbPassConf";
            tbPassConf.PasswordChar = '*';
            tbPassConf.Size = new Size(216, 32);
            tbPassConf.TabIndex = 4;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Cursor = Cursors.Hand;
            lblLogin.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point);
            lblLogin.Image = Properties.Resources.form_background;
            lblLogin.Location = new Point(404, 455);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(239, 21);
            lblLogin.TabIndex = 17;
            lblLogin.Text = "Already have an account? Log in.";
            lblLogin.Click += lblLogin_Click;
            // 
            // SignUpForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.form_background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(984, 661);
            Controls.Add(lblLogin);
            Controls.Add(label7);
            Controls.Add(tbPassConf);
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
        private Label label7;
        private TextBox tbPassConf;
        private Label lblLogin;
    }
}
