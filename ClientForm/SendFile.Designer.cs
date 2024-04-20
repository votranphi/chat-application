namespace ClientForm
{
    partial class SendFile
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listViewReceiver = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.btnWaitForFiles = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSendFiles = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIpAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPortConnect = new System.Windows.Forms.TextBox();
            this.listViewSender = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(808, 557);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listViewReceiver);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnWaitForFiles);
            this.tabPage1.Controls.Add(this.txtPort);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(800, 524);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Recevie";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listViewReceiver
            // 
            this.listViewReceiver.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listViewReceiver.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listViewReceiver.GridLines = true;
            this.listViewReceiver.HideSelection = false;
            this.listViewReceiver.Location = new System.Drawing.Point(3, 36);
            this.listViewReceiver.Name = "listViewReceiver";
            this.listViewReceiver.Size = new System.Drawing.Size(794, 477);
            this.listViewReceiver.TabIndex = 16;
            this.listViewReceiver.UseCompatibleStateImageBehavior = false;
            this.listViewReceiver.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "File Name";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "File Size";
            this.columnHeader5.Width = 200;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Status";
            this.columnHeader6.Width = 200;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Total Time";
            this.columnHeader7.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(8, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 22);
            this.label1.TabIndex = 15;
            this.label1.Text = "Port :";
            // 
            // btnWaitForFiles
            // 
            this.btnWaitForFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWaitForFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnWaitForFiles.Location = new System.Drawing.Point(648, 3);
            this.btnWaitForFiles.Name = "btnWaitForFiles";
            this.btnWaitForFiles.Size = new System.Drawing.Size(152, 27);
            this.btnWaitForFiles.TabIndex = 14;
            this.btnWaitForFiles.Text = "Wait For Files";
            this.btnWaitForFiles.UseVisualStyleBackColor = true;
            this.btnWaitForFiles.Click += new System.EventHandler(this.btnWaitForFiles_Click);
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPort.Location = new System.Drawing.Point(66, 5);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(576, 24);
            this.txtPort.TabIndex = 13;
            this.txtPort.Text = "11000";
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPort.TextChanged += new System.EventHandler(this.txtPort_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnSendFiles);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtIpAddress);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txtPortConnect);
            this.tabPage2.Controls.Add(this.listViewSender);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(800, 524);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Send";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSendFiles
            // 
            this.btnSendFiles.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendFiles.Location = new System.Drawing.Point(3, 482);
            this.btnSendFiles.Name = "btnSendFiles";
            this.btnSendFiles.Size = new System.Drawing.Size(793, 35);
            this.btnSendFiles.TabIndex = 21;
            this.btnSendFiles.Text = "Send Files";
            this.btnSendFiles.UseVisualStyleBackColor = true;
            this.btnSendFiles.Click += new System.EventHandler(this.btnSendFiles_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(1, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 22);
            this.label3.TabIndex = 20;
            this.label3.Text = "IP :";
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtIpAddress.Location = new System.Drawing.Point(43, 7);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(526, 24);
            this.txtIpAddress.TabIndex = 19;
            this.txtIpAddress.Text = "127.0.0.1";
            this.txtIpAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(575, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 22);
            this.label2.TabIndex = 18;
            this.label2.Text = "Port :";
            // 
            // txtPortConnect
            // 
            this.txtPortConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPortConnect.Location = new System.Drawing.Point(651, 6);
            this.txtPortConnect.Name = "txtPortConnect";
            this.txtPortConnect.Size = new System.Drawing.Size(143, 24);
            this.txtPortConnect.TabIndex = 17;
            this.txtPortConnect.Text = "11000";
            this.txtPortConnect.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listViewSender
            // 
            this.listViewSender.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader8});
            this.listViewSender.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listViewSender.GridLines = true;
            this.listViewSender.HideSelection = false;
            this.listViewSender.Location = new System.Drawing.Point(3, 48);
            this.listViewSender.Name = "listViewSender";
            this.listViewSender.Size = new System.Drawing.Size(794, 428);
            this.listViewSender.TabIndex = 10;
            this.listViewSender.UseCompatibleStateImageBehavior = false;
            this.listViewSender.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File Name";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "File Size";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Total Time";
            this.columnHeader8.Width = 200;
            // 
            // SendFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 558);
            this.Controls.Add(this.tabControl1);
            this.Name = "SendFile";
            this.Text = "SendFile";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnWaitForFiles;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.ListView listViewSender;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ListView listViewReceiver;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIpAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPortConnect;
        private System.Windows.Forms.Button btnSendFiles;
    }
}