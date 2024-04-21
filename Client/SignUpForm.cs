using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class SignUpForm : Form
    {
        private TcpClient tcpClient;
        private IPEndPoint ipep;
        private StreamWriter streamWriter;
        private StreamReader streamReader;

        public SignUpForm()
        {
            InitializeComponent();
        }

        private void waitForSignUpResultFromServer()
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            streamWriter.WriteLine("<Sign_Up>");
            streamWriter.WriteLine($"{username}|{password}");

            // waitForSignUpResultFromServer
            string msgFromServer = streamReader.ReadLine();

            // solve the signals from server
            if (msgFromServer == "<Username_Exists>")
            {
                MessageBox.Show("Sign up failed! Username already existed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (msgFromServer == "<Success>")
            {
                Thread clientFormThread = new Thread(() => Application.Run(new ClientForm(tcpClient, username)));
                // set the apartment state for the thread to STA for opening OpenFileDialog
                clientFormThread.ApartmentState = ApartmentState.STA;
                clientFormThread.Start();

                this.Invoke((MethodInvoker)delegate
                {
                    this.Close();
                });
                return;
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            // exceptions catching
            if (tbUsername.Text == "" || tbPassword.Text == "" || tbServerIP.Text == "" || tbPort.Text == "" || tbPassConf.Text == "")
            {
                MessageBox.Show("Empty Fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbPassConf.Text != tbPassword.Text)
            {
                MessageBox.Show("The password confirmation does not match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            Thread resultListener = new Thread(new ThreadStart(waitForSignUpResultFromServer));
            resultListener.Start();
            resultListener.IsBackground = true;
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            new Thread(() => Application.Run(new LoginForm())).Start();
            this.Close();
        }
    }
}
