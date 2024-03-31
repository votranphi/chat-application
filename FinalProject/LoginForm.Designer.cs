namespace FinalProject
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 14F);
            textBox1.Location = new Point(404, 302);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(216, 32);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 14F);
            textBox2.Location = new Point(404, 377);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(216, 32);
            textBox2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Image = Properties.Resources.form_background;
            label1.Location = new Point(307, 305);
            label1.Name = "label1";
            label1.Size = new Size(97, 25);
            label1.TabIndex = 2;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Image = Properties.Resources.form_background;
            label2.Location = new Point(307, 380);
            label2.Name = "label2";
            label2.Size = new Size(91, 25);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F);
            label3.Image = Properties.Resources.form_background;
            label3.Location = new Point(404, 234);
            label3.Name = "label3";
            label3.Size = new Size(216, 30);
            label3.TabIndex = 4;
            label3.Text = "Chat with your friend";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Highlight;
            button1.Location = new Point(473, 443);
            button1.Name = "button1";
            button1.Size = new Size(80, 40);
            button1.TabIndex = 5;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = Properties.Resources.chat3_png;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(452, 126);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(131, 105);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.form_background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(984, 661);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(1000, 700);
            MinimumSize = new Size(1000, 700);
            Name = "LoginForm";
            Text = "Chat";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private PictureBox pictureBox1;
    }
}
