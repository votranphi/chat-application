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
            tbGroupName = new TextBox();
            tbUsersname = new TextBox();
            btnCreate = new Button();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 0;
            label1.Text = "Group's name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 36);
            label2.Name = "label2";
            label2.Size = new Size(71, 15);
            label2.TabIndex = 1;
            label2.Text = "Users' name";
            // 
            // tbGroupName
            // 
            tbGroupName.Location = new Point(99, 6);
            tbGroupName.Name = "tbGroupName";
            tbGroupName.Size = new Size(234, 23);
            tbGroupName.TabIndex = 2;
            // 
            // tbUsersname
            // 
            tbUsersname.Location = new Point(99, 33);
            tbUsersname.Name = "tbUsersname";
            tbUsersname.Size = new Size(234, 23);
            tbUsersname.TabIndex = 3;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(133, 62);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(75, 23);
            btnCreate.TabIndex = 4;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 92);
            label3.Name = "label3";
            label3.Size = new Size(334, 15);
            label3.TabIndex = 5;
            label3.Text = "Rule1: Every two usernames should be separated by a comma.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 110);
            label4.Name = "label4";
            label4.Size = new Size(154, 15);
            label4.TabIndex = 6;
            label4.Text = "Rule2: Enter your username.";
            // 
            // CreateGroupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(345, 134);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnCreate);
            Controls.Add(tbUsersname);
            Controls.Add(tbGroupName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CreateGroupForm";
            Text = "CreateGroupForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox tbGroupName;
        private TextBox tbUsersname;
        private Button btnCreate;
        private Label label3;
        private Label label4;
    }
}