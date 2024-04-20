using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientForm
{
    public partial class ClientForm : Form
    {
        private Socket clientSocket = null;
        private delegate void SafeCallDelegate(string text);
        private bool connected = false;
        private static int _buff_size = 2048;
        private byte[] _buffer = new byte[_buff_size];

        public ClientForm()
        {
            InitializeComponent();
            clientSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            IPAddress serverIp = IPAddress.Parse(ipInput.Text);
            int serverPort = int.Parse(portInput.Text);
            IPEndPoint serverEp = new IPEndPoint(serverIp, serverPort);
            if (connected)
            {
                connected = false;
                clientSocket.BeginDisconnect(true, new AsyncCallback(onDisconnecting), clientSocket);
                richTextBox1.Text += "Disconnected from " + serverEp.ToString() + "\r\n";
                connectBtn.Text = "Connect";
            }
            else
            {
                connected = true;
                clientSocket.BeginConnect(serverEp, new AsyncCallback(onConnecting), clientSocket);
                richTextBox1.Text += "Connected to " + serverEp.ToString() + "\r\n";
                connectBtn.Text = "Disconnect";
            }
        }

        public void onDisconnecting(IAsyncResult ar)
        {
            Socket clientSocket = (Socket)ar.AsyncState;
            clientSocket.EndDisconnect(ar);
        }

        public void onConnecting(IAsyncResult ar)
        {
            Socket clientSocket = (Socket)ar.AsyncState;
            clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(onReceive), clientSocket);
            clientSocket.EndConnect(ar);
        }

        public void onReceive(IAsyncResult ar)
        {
            Socket clientSocket = (Socket)ar.AsyncState;
            int readbytes = clientSocket.EndReceive(ar);
            string s = Encoding.UTF8.GetString(_buffer, 0, readbytes);
            UpdateChatHistoryThreadSafe(s);

            clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(onReceive), clientSocket);
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text += "[You] " + richTextBox2.Text + "\r\n";
                clientSocket.Send(Encoding.UTF8.GetBytes("[" + nameInput.Text + "] " + richTextBox2.Text));
                richTextBox2.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateChatHistoryThreadSafe(string text)
        {
            if (richTextBox1.InvokeRequired)
            {
                var d = new SafeCallDelegate(UpdateChatHistoryThreadSafe);
                richTextBox1.Invoke(d, new object[] { text });
            }
            else
            {
                richTextBox1.Text += text + "\r\n";
            }
        }

        private void richTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    sendBtn_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            int sum = richTextBox2.Text.Length;

            txtCount.Text = sum.ToString() + "/2000";
            if (sum > 2000)
            {
                MessageBox.Show("Vui lòng nhập ít hơn 2000 kí tự", "Thông báo lỗi");
                this.Close();
            }
        }

        

        private void sendFileBtn_Click_1(object sender, EventArgs e)
        {
            SendFile send = new SendFile();
            send.ShowDialog();
        }

        private void txtCount_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
