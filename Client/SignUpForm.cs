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
            streamWriter.WriteLine("<Sign_Up>");
            streamWriter.WriteLine($"{tbUsername.Text}|{tbPassword}");

            string msgFromServer = streamReader.ReadLine();

            // solve the signals from server
            if (msgFromServer == "<Username_Exists>")
            {
                MessageBox.Show("Sign up failed! Username already existed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                streamWriter.Close();
                streamReader.Close();
                tcpClient.Close();
                return;
            }
            if (msgFromServer == "<Success>")
            {
                new Thread(() => Application.Run(new ClientForm(tcpClient, tbUsername.Text))).Start();
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
            if (tbUsername.Text == "" || tbPassword.Text == "" || tbServerIP.Text == "" || tbPort.Text == "")
            {
                MessageBox.Show("Empty Fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        }
    }
}
