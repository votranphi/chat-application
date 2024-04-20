using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Client
{
    partial class CreateGroupForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tbGroupName = new TextBox();
            btnCreate = new Button();
            tbUsersname = new TextBox();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(134, 41);
            label1.Name = "label1";
            label1.Size = new Size(304, 45);
            label1.TabIndex = 0;
            label1.Text = "Create a group chat";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(63, 132);
            label2.Name = "label2";
            label2.Size = new Size(129, 25);
            label2.TabIndex = 1;
            label2.Text = "Group's name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(63, 202);
            label3.Name = "label3";
            label3.Size = new Size(160, 25);
            label3.TabIndex = 2;
            label3.Text = "Group's members";
            // 
            // tbGroupName
            // 
            tbGroupName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbGroupName.Location = new Point(221, 132);
            tbGroupName.Name = "tbGroupName";
            tbGroupName.Size = new Size(260, 32);
            tbGroupName.TabIndex = 0;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = SystemColors.Highlight;
            btnCreate.Cursor = Cursors.Hand;
            btnCreate.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnCreate.Location = new Point(271, 297);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(152, 40);
            btnCreate.TabIndex = 2;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // tbUsersname
            // 
            tbUsersname.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbUsersname.Location = new Point(221, 199);
            tbUsersname.Name = "tbUsersname";
            tbUsersname.Size = new Size(260, 32);
            tbUsersname.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(22, 452);
            label5.Name = "label5";
            label5.Size = new Size(532, 25);
            label5.TabIndex = 1;
            label5.Text = "Rule1: Every two usernames should be separated by a comma.";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(22, 490);
            label6.Name = "label6";
            label6.Size = new Size(286, 25);
            label6.TabIndex = 1;
            label6.Text = "Rule2: Enter your username also.";
            // 
            // CreateGroupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 128, 255);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(584, 561);
            Controls.Add(btnCreate);
            Controls.Add(tbUsersname);
            Controls.Add(tbGroupName);
            Controls.Add(label3);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximumSize = new Size(600, 600);
            MinimumSize = new Size(600, 600);
            Name = "CreateGroupForm";
            Text = "CreateGroupForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbGroupName;
        private Button btnCreate;
        private TextBox tbUsersname;
        private Label label5;
        private Label label6;
    }
}