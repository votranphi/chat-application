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
            tcpListener = new TcpListener(new IPEndPoint(IPAddress.Any, int.Parse(portInput.Text)));
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
                    // splitString[0] is username, splitString[1] is password from new client
                    string[] splitString = usernameAndPassword.Split('|');

                    if (USER.ContainsKey(splitString[0]))
                    {
                        streamWriter.WriteLine("<Username_Exists>");
                    }
                    else
                    {
                        streamWriter.WriteLine("<Success>");
                        // add new username and password to USER list
                        USER.Add(splitString[0], splitString[1]);
                        // add new username and TcpClient to CLIENT list
                        CLIENT.Add(splitString[0], _client);
                        // print the notifications to richtextbox
                        IPEndPoint remoteIpEndPoint = _client.Client.RemoteEndPoint as IPEndPoint; // use to get the client's IP and client's port
                        UpdateClientsStatusThreadSafe($"[{DateTime.Now}] {splitString[0]}({remoteIpEndPoint.Address}:{remoteIpEndPoint.Port}) has just signed up and logged in!\n");
                        // new thread for the client has just signed up successfully
                        Thread receiveThread = new Thread(new ThreadStart(() => receiveFromClient(splitString[0])));
                        receiveThread.Start();
                        receiveThread.IsBackground = true;
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
                            // print the notifications to richtextbox
                            IPEndPoint remoteIpEndPoint = _client.Client.RemoteEndPoint as IPEndPoint; // use to get the client's IP and client's port
                            UpdateClientsStatusThreadSafe($"[{DateTime.Now}] {splitString[0]}({remoteIpEndPoint.Address}:{remoteIpEndPoint.Port}) has just logged in!\n");
                            // new thread for the client has just logged in successfully
                            Thread receiveThread = new Thread(new ThreadStart(() => receiveFromClient(splitString[0])));
                            receiveThread.Start();
                            receiveThread.IsBackground = true;
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

        private void receiveFromClient(string username)
        {
            TcpClient _client = CLIENT[username];
            StreamReader streamReader = new StreamReader(_client.GetStream());
            StreamWriter streamWriter = new StreamWriter(_client.GetStream());
            streamWriter.AutoFlush = true;

            while (isServerRunning)
            {
                string msgFromClient = streamReader.ReadLine();

                // solve the logout signal from client
                if (msgFromClient == "<Logout>")
                {
                    IPEndPoint remoteIpEndPoint = _client.Client.RemoteEndPoint as IPEndPoint; // use to get the client's IP and client's port\
                    UpdateClientsStatusThreadSafe($"[{DateTime.Now}] {username}({remoteIpEndPoint.Address}:{remoteIpEndPoint.Port}) has just logged out!\n");
                    break;
                }

                // solve the create group signal from client
                if (msgFromClient == "<Cre_Group>")
                {
                    string groupnameAndUsersname = streamReader.ReadLine();

                    // splitString[0] is group's name, splitString[1] is a list of usernames separated by a comma
                    string[] splitString = groupnameAndUsersname.Split('|');
                    string[] _username = splitString[1].Split(',');

                    // delete all leading and trailing white-spaces then add to userList
                    List<string> userList = new List<string>();
                    for (int i = 0; i < _username.Length; i++)
                    {
                        userList.Add(_username[i].Trim());
                    }

                    // finally, add all the things to the GROUP list
                    GROUP.Add(splitString[0], userList);
                }

                // solve the image signal from client
                if (msgFromClient == "<Image>")
                {
                    string senderAndReceiver = streamReader.ReadLine();
                    // splitString[0] is sender's username, splitString[1] is receiver's username or group's name
                    string[] splitString = senderAndReceiver.Split('|');

                    // maximum size of image is 524288 bytes
                    byte[] bytes = new byte[524288];
                    // wait for client side to complete writing data
                    streamReader.BaseStream.Read(bytes, 0, bytes.Length);

                    // if receiver's name is in CLIENT list, then do sending the message to it
                    if (CLIENT.ContainsKey(splitString[1]))
                    {
                        StreamWriter receiverSW = new StreamWriter(CLIENT[splitString[1]].GetStream());
                        receiverSW.AutoFlush = true;
                        receiverSW.WriteLine("<Image>");
                        receiverSW.WriteLine(splitString[0]);
                        receiverSW.BaseStream.Write(bytes, 0, bytes.Length);
                    }
                    else
                    // if group's name is in GROUP list, then do sending the message to users in it
                    if (GROUP.ContainsKey(splitString[1]))
                    {
                        List<string> usersInGroup = GROUP[splitString[1]];
                        foreach (string user in usersInGroup)
                        {
                            // only send if the... it's hard to say...
                            if (_client != CLIENT[user])
                            {
                                StreamWriter receiverSW = new StreamWriter(CLIENT[user].GetStream());
                                receiverSW.AutoFlush = true;
                                receiverSW.WriteLine("<Image>");
                                receiverSW.WriteLine(splitString[0]);
                                receiverSW.BaseStream.Write(bytes, 0, bytes.Length);
                            }
                        }
                    }
                    else
                    {
                        streamWriter.WriteLine("<UoG_Not_Exist>"); // User_Or_Group_Not_Exist
                    }

                    continue;
                }

                // solve the message signal from client
                if (msgFromClient == "<Message>")
                {
                    string senderAndReceiverAndMsg = streamReader.ReadLine();
                    // splitString[0] is sender's username, splitString[1] is receiver's username or group's name, splitString[3] is message
                    string[] splitString = senderAndReceiverAndMsg.Split('|');

                    // if receiver's name is in CLIENT list, then do sending the message to it
                    if (CLIENT.ContainsKey(splitString[1]))
                    {
                        StreamWriter receiverSW = new StreamWriter(CLIENT[splitString[1]].GetStream());
                        receiverSW.AutoFlush = true;
                        receiverSW.WriteLine("<Message>");
                        receiverSW.WriteLine(senderAndReceiverAndMsg);
                    }
                    else
                    // if group's name is in GROUP list, then do sending the message to users in it
                    if (GROUP.ContainsKey(splitString[1]))
                    {
                        List<string> usersInGroup = GROUP[splitString[1]];
                        foreach (string user in usersInGroup)
                        {
                            // only send if the... it's hard to say...
                            if (_client != CLIENT[user])
                            {
                                StreamWriter receiverSW = new StreamWriter(CLIENT[user].GetStream());
                                receiverSW.AutoFlush = true;
                                receiverSW.WriteLine("<Message>");
                                receiverSW.WriteLine(senderAndReceiverAndMsg);
                            }
                        }
                    }
                    else
                    {
                        streamWriter.WriteLine("<UoG_Not_Exist>"); // User_Or_Group_Not_Exist
                    }
                }
            }
        }

        private void listenBtn_Click(object sender, EventArgs e)
        {
            // BUG IS IN THERE WHEN CLICK ON DISCONNECT BUTTON IN SERVER'S FORM
            if (isServerRunning)
            {
                isServerRunning = false;
                tcpListener.Stop();
                statusAndMsg.Text += $"[{DateTime.Now}] Stop listening with ip address {ipInput.Text} on port {portInput.Text}\n";
                listenBtn.Text = "Listen";
            }
            else
            {
                isServerRunning = true;
                Thread listenThread = new Thread(this.listen);
                listenThread.Start();
                listenThread.IsBackground = true;
                statusAndMsg.Text += $"[{DateTime.Now}] Start listening with ip address {ipInput.Text} on port {portInput.Text}\n";
                listenBtn.Text = "Stop";
            }
        }

        #region UpdateThreadSafe

        private void UpdateClientsStatusThreadSafe(string text)
        {
            if (statusAndMsg.InvokeRequired)
            {
                var d = new SafeCallDelegate(UpdateClientsStatusThreadSafe);
                statusAndMsg.Invoke(d, new object[] { text });
            }
            else
            {
                statusAndMsg.Text += text;
            }
        }

        #endregion
    }
}