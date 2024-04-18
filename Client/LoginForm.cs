using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Client
{
    public partial class LoginForm : Form
    {
        private TcpClient tcpClient;
        private IPEndPoint ipep;
        private StreamWriter streamWriter;
        private StreamReader streamReader;

        public LoginForm()
        {
            InitializeComponent();
        }
        private void waitForLoginResultFromServer()
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            streamWriter.WriteLine("<Login>");
            streamWriter.WriteLine($"{username}|{password}");

            string msgFromServer = streamReader.ReadLine();

            if (msgFromServer == "<Wrong_Password>")
            {
                MessageBox.Show("Wrong password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (msgFromServer == "<Username_Not_Exist>")
            {
                MessageBox.Show("Username doesn't exist! Please sign up!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (msgFromServer == "<Success>")
            {
                new Thread(() => Application.Run(new ClientForm(tcpClient, username))).Start();
                this.Invoke((MethodInvoker)delegate
                {
                    this.Close();
                });
                return;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // exceptions catching
            if (tbUsername.Text == "" || tbPassword.Text == "" || tbServerIP.Text == "" || tbPort.Text == "")
            {
                MessageBox.Show("Empty Fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // implementation
            tcpClient = new TcpClient();
            ipep = new IPEndPoint(IPAddress.Parse(tbServerIP.Text), int.Parse(tbPort.Text));
            try
            {
                tcpClient.Connect(ipep);
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Server isn't running! Please try again later!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            streamWriter = new StreamWriter(tcpClient.GetStream());
            streamReader = new StreamReader(tcpClient.GetStream());
            streamWriter.AutoFlush = true;

            Thread resultListener = new Thread(new ThreadStart(waitForLoginResultFromServer));
            resultListener.Start();
            resultListener.IsBackground = true;
        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {
            new Thread(() => Application.Run(new SignUpForm())).Start();
            this.Close();
        }
    }
}
