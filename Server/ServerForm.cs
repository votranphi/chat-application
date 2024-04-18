using System.Net.Sockets;
using System.Net;
using System.Net.Http;

namespace Server
{
    public partial class ServerForm : Form
    {
        private TcpListener tcpListener;
        private bool isServerRunning = false;
        // username to its password
        private Dictionary<string, string> USER = new Dictionary<string, string>();
        // username to TcpClient
        private Dictionary<string, TcpClient> CLIENT = new Dictionary<string, TcpClient>();
        // group's name to list of usernames
        private Dictionary<string, List<string>> GROUP = new Dictionary<string, List<string>>();
        private delegate void SafeCallDelegate(string text);
        private delegate void SafeCallDelegateImage(Bitmap bmp);

        public ServerForm()
        {
            InitializeComponent();
        }

        private void listen()
        {
            try
            {
                tcpListener = new TcpListener(new IPEndPoint(IPAddress.Parse(ipInput.Text), int.Parse(portInput.Text)));
                tcpListener.Start();

                while (isServerRunning)
                {
                    // accepts if there is a client
                    TcpClient _client = tcpListener.AcceptTcpClient();

                    StreamWriter streamWriter = new StreamWriter(_client.GetStream());
                    StreamReader streamReader = new StreamReader(_client.GetStream());
                    streamWriter.AutoFlush = true;

                    string msgFromClient = streamReader.ReadLine();

                    // solve the sign up signal from client
                    if (msgFromClient == "<Sign_Up>")
                    {
                        string usernameAndPassword = streamReader.ReadLine();
                        string[] splitString = usernameAndPassword.Split('|');

                        if (USER.ContainsKey(splitString[0]))
                        {
                            streamWriter.WriteLine("<Username_Exists>");
                        }
                        else
                        {
                            streamWriter.WriteLine("<Success>");
                            USER.Add(splitString[0], splitString[1]);
                        }

                        continue;
                    }

                    // solve the login signal from client
                    if (msgFromClient == "<Login>")
                    {
                        string usernameAndPassword = streamReader.ReadLine();
                        string[] splitString = usernameAndPassword.Split('|');

                        if (USER.ContainsKey(splitString[0]))
                        {
                            if (USER[splitString[0]] == splitString[1])
                            {
                                streamWriter.WriteLine("<Success>");
                            }
                            else
                            {
                                streamWriter.WriteLine("<Wrong_Password>");
                            }
                        }
                        else
                        {
                            streamWriter.WriteLine("<Username_Not_Exist>");
                        }

                        continue;
                    }
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void receiveFromClient(string username, TcpClient _client)
        {
            StreamReader streamReader = new StreamReader(_client.GetStream());
            try
            {
                while (isServerRunning)
                {
                    string msgFromClient = streamReader.ReadLine();

                    if (msgFromClient == "<Disconnect>")
                    {
                        CLIENT.Remove(username);
                        // Problem 1: two lines below will send the empty string to the client after close
                        _client.Close();
                        streamReader.Close();
                        UpdateChatHistoryThreadSafe($"[{DateTime.Now.ToString()}] {username} disconnected from server!\n");
                        break;
                    }

                    if (msgFromClient == "<Image>")
                    {
                        // maximum size of image is 524288 bytes
                        byte[] bytes = new byte[524288];
                        // wait for client side to complete writing data
                        Thread.Sleep(1000);
                        streamReader.BaseStream.Read(bytes, 0, bytes.Length);

                        foreach (TcpClient i in CLIENT.Values)
                        {
                            if (i != _client)
                            {
                                StreamWriter _streamWriter = new StreamWriter(i.GetStream());
                                _streamWriter.AutoFlush = true;
                                _streamWriter.WriteLine("<Image>");
                                _streamWriter.BaseStream.Write(bytes, 0, bytes.Length);
                            }
                        }

                        Bitmap bmp;
                        using (var ms = new MemoryStream(bytes))
                        {
                            bmp = new Bitmap(ms);
                        }

                        UpdateImageThreadSafe(bmp);

                        continue;
                    }

                    string formattedMsg = $"[{DateTime.Now}] {username}: {msgFromClient}";

                    // send the received message to all the clients except the incoming one
                    foreach (TcpClient i in CLIENT.Values)
                    {
                        if (i != _client)
                        {
                            StreamWriter _streamWriter = new StreamWriter(i.GetStream());
                            _streamWriter.WriteLine(formattedMsg);
                            _streamWriter.AutoFlush = true;
                        }
                    }

                    UpdateChatHistoryThreadSafe(formattedMsg + "\n");
                }
            }
            catch (SocketException sockEx)
            {
                _client.Close();
                streamReader.Close();
            }
        }

        private void listenBtn_Click(object sender, EventArgs e)
        {
            if (isServerRunning)
            {
                isServerRunning = false;
                tcpListener.Stop();
                statusAndMsg.Text += $"[{DateTime.Now.ToString()}] Stop listening with ip address {ipInput.Text} on port {portInput.Text}\n";
                listenBtn.Text = "Listen";
            }
            else
            {
                isServerRunning = true;
                Thread listenThread = new Thread(this.listen);
                listenThread.Start();
                statusAndMsg.Text += $"[{DateTime.Now.ToString()}] Start listening with ip address {ipInput.Text} on port {portInput.Text}\n";
                listenBtn.Text = "Stop";
            }
        }

        private void UpdateChatHistoryThreadSafe(string text)
        {
            if (statusAndMsg.InvokeRequired)
            {
                var d = new SafeCallDelegate(UpdateChatHistoryThreadSafe);
                statusAndMsg.Invoke(d, new object[] { text });
            }
            else
            {
                statusAndMsg.Text += text;
            }
        }

        private void UpdateImageThreadSafe(Bitmap bmp)
        {
            if (statusAndMsg.InvokeRequired)
            {
                var d = new SafeCallDelegateImage(UpdateImageThreadSafe);
                statusAndMsg.Invoke(d, new object[] { bmp });
            }
            else
            {
                Clipboard.SetDataObject(bmp);
                statusAndMsg.Text += "\n";
                // move cursor to the end of the RTB
                statusAndMsg.Select(statusAndMsg.Text.Length - 1, 0);
                // scroll to the end of the RTB
                statusAndMsg.ScrollToCaret();
                statusAndMsg.Paste();
            }
        }

        #region Responsive



        #endregion
    }
}