using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace ServerForm
{
    public partial class ServerForm : Form
    {
        private Socket serverSocket = null;
        private bool started = false;
        private IPAddress _ipAddress = null;
        private int _port = 0;
        private static int _buff_size = 2048;
        private byte[] _buffer = new byte[_buff_size];
        private delegate void SafeCallDelegate(string text);
        private List<Socket> clientSockets = new List<Socket>();
        DateTime now;

        public ServerForm()
        {
            InitializeComponent();
            serverSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        }

        private void listenBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (started)
                {
                    started = false;
                    now = DateTime.Now;
                    richTextBox1.Text += "[" + now.ToString() + "] " + "Stop listening with IP address " + ipInput.Text + " on port " + portInput.Text + "\r\n";
                    listenBtn.Text = "Listen";
                    serverSocket.Close();
                }
                else
                {
                    now = DateTime.Now;
                    richTextBox1.Text += "[" + now.ToString() + "] " + "Start listening with IP address " + ipInput.Text + " on port " + portInput.Text + "\r\n";
                    listenBtn.Text = "Stop";
                    this._port = int.Parse(portInput.Text);
                    this._ipAddress = IPAddress.Parse(ipInput.Text);
                    listen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listen()
        {
            serverSocket.Bind(new IPEndPoint(_ipAddress, _port));
            serverSocket.Listen(10);
            started = true;
            serverSocket.BeginAccept(new AsyncCallback(onAccepting), serverSocket);
        }

        public void onAccepting(IAsyncResult ar)
        {
            Socket serverSocket = (Socket)ar.AsyncState;
            Socket clientSocket = serverSocket.EndAccept(ar);
            clientSockets.Add(clientSocket); // mỗi khi có một clientSocket mới kết nối thì sẽ thêm vào list các clientSockets

            now = DateTime.Now;
            UpdateChatHistoryThreadSafe("[" + now.ToString() + "] " + "Accept connection from " + clientSocket.RemoteEndPoint.ToString());
            clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(onReceive), clientSocket);

            serverSocket.BeginAccept(new AsyncCallback(onAccepting), serverSocket); // mở lại accept có thể accept thêm nhiều client nữa
        }

        //public void onReceive(IAsyncResult ar)
        //{
        //    Socket clientSocket = (Socket)ar.AsyncState;
        //    var readbytes = clientSocket.EndReceive(ar);

        //    string s = Encoding.UTF8.GetString(_buffer, 0, readbytes);
        //    UpdateChatHistoryThreadSafe(s);

        //    foreach (Socket i in clientSockets) // gửi thông điệp đến tất cả các client khác trừ client vừa gửi đến
        //    {
        //        if (clientSockets.IndexOf(i) != clientSockets.IndexOf(clientSocket))
        //        {
        //            i.Send(_buffer, readbytes, SocketFlags.None);
        //        }
        //    }

        //    clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(onReceive), clientSocket);
        //}

        public void onReceive(IAsyncResult ar)
        {
            Socket clientSocket = (Socket)ar.AsyncState;

            try
            {
                var readbytes = clientSocket.EndReceive(ar);

                if (readbytes > 0)
                {
                    string s = Encoding.UTF8.GetString(_buffer, 0, readbytes);
                    UpdateChatHistoryThreadSafe(s);

                    foreach (Socket i in clientSockets) // gửi thông điệp đến tất cả các client khác trừ client vừa gửi đến
                    {
                        if (clientSockets.IndexOf(i) != clientSockets.IndexOf(clientSocket))
                        {
                            i.Send(_buffer, readbytes, SocketFlags.None);
                        }
                    }
                }
                else
                {
                    // Xử lý trường hợp socket bị đóng hoặc timeout
                    MessageBox.Show("Socket bị đóng hoặc timeout.");
                }
            }
            catch (SocketException ex)
            {
                // Xử lý các lỗi khác
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(onReceive), clientSocket);
        }

        //void readFromSocket(Socket clientSocket)
        //{
        //    while (started && clientSocket != null)
        //    {
        //        int readbytes = clientSocket.Receive(_buffer);
        //        string s = Encoding.UTF8.GetString(_buffer);
        //        UpdateChatHistoryThreadSafe(s + "\n");
        //    }
        //}

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

        
    }
}
