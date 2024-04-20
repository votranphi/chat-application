using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class CreateGroupForm : Form
    {
        private TcpClient tcpClient;
        private string username;

        public CreateGroupForm(TcpClient tcpClient, string username)
        {
            this.tcpClient = tcpClient;
            this.username = username;
            InitializeComponent();

            this.Text = $"{username}'s CreateGroupForm";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (tbGroupName.Text == "" || tbUsersname.Text == "")
            {
                MessageBox.Show("Empty Fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            StreamWriter streamWriter = new StreamWriter(tcpClient.GetStream());
            streamWriter.AutoFlush = true;
            streamWriter.WriteLine("<Cre_Group>"); // send the signal message to create group
            streamWriter.WriteLine($"{tbGroupName.Text}|{tbUsersname.Text}");

            this.Close();
        }
    }
}
