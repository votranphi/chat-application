using System.Net.Sockets;
using System.Net;
using System.Net.Http;
using Microsoft.VisualBasic.ApplicationServices;

namespace Server
{
    public partial class ServerForm : Form
    {
        private TcpListener tcpListener;
        private bool isServerRunning = false;
        // username to its password
        private Dictionary<string, string> USER = new Dictionary<string, string>();
        // username to its TcpClient
        private Dictionary<string, TcpClient> CLIENT = new Dictionary<string, TcpClient>();
        // group's name to list of usernames
        private Dictionary<string, List<string>> GROUP = new Dictionary<string, List<string>>();
        // username to his/her status (1 - online, 0 - offline)
        private Dictionary<string, bool> STATUS = new Dictionary<string, bool>();

        private delegate void SafeCallDelegate(string text);

        // maximum size of buffer is 100MB
        private static int buffer_size = 104857600;
        private byte[] buffer = new byte[buffer_size];

        public ServerForm()
        {
            InitializeComponent();
        }

        // lang nghe coi co TCPclient nao ket noi toi khong
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
                        // add new username and his/her status to STATUS list
                        STATUS.Add(splitString[0], true);

                        // send new online user signal to other clients
                        foreach (string user in USER.Keys)
                        {
                            if (user != splitString[0] && STATUS[user] == true)
                            {
                                StreamWriter _streamWriter = new StreamWriter(CLIENT[user].GetStream());
                                _streamWriter.AutoFlush = true;
                                _streamWriter.WriteLine("<User_Onl>");
                                _streamWriter.WriteLine(splitString[0]);
                            }
                        }

                        // print the notifications to richtextbox
                        IPEndPoint remoteIpEndPoint = _client.Client.RemoteEndPoint as IPEndPoint; // use to get the client's IP and client's port
                        UpdateClientsStatusThreadSafe($"[{DateTime.Now}] {splitString[0]}({remoteIpEndPoint.Address}:{remoteIpEndPoint.Port}) has just signed up and logged in!\n");
                        // new thread for the client has just signed up successfully
                        Thread receiveThread = new Thread(new ThreadStart(() => receiveFromClient(splitString[0])));
                        receiveThread.Start();
                        receiveThread.IsBackground = true;

                        sendOnlineUsernamesAndGroupnames(splitString[0], streamWriter);
                    }

                    continue;
                }

                // solve the login signal from client
                if (msgFromClient == "<Login>")
                {
                    string usernameAndPassword = streamReader.ReadLine();
                    // splitString[0] is username, splitString[1] is password from new client
                    string[] splitString = usernameAndPassword.Split('|');

                    // check if the user name is in USER list
                    if (USER.ContainsKey(splitString[0]))
                    {
                        // check if the password is correct
                        if (USER[splitString[0]] == splitString[1])
                        {
                            // check if the user is inactive
                            if (STATUS[splitString[0]] == false)
                            {
                                streamWriter.WriteLine("<Success>");
                                // change the user's status in STATUS list to true
                                STATUS[splitString[0]] = true;
                                // add the new TcpClient in CLIENT list when user Logged In successfully
                                CLIENT.Add(splitString[0], _client);

                                // send new online user signal to other clients
                                foreach (string user in USER.Keys)
                                {
                                    if (user != splitString[0] && STATUS[user] == true)
                                    {
                                        StreamWriter _streamWriter = new StreamWriter(CLIENT[user].GetStream());
                                        _streamWriter.AutoFlush = true;
                                        _streamWriter.WriteLine("<User_Onl>");
                                        _streamWriter.WriteLine(splitString[0]);
                                    }
                                }

                                // print the notifications to richtextbox
                                IPEndPoint remoteIpEndPoint = _client.Client.RemoteEndPoint as IPEndPoint; // use to get the client's IP and client's port
                                UpdateClientsStatusThreadSafe($"[{DateTime.Now}] {splitString[0]}({remoteIpEndPoint.Address}:{remoteIpEndPoint.Port}) has just logged in!\n");
                                // new thread for the client has just logged in successfully
                                Thread receiveThread = new Thread(new ThreadStart(() => receiveFromClient(splitString[0])));
                                receiveThread.Start();
                                receiveThread.IsBackground = true;

                                sendOnlineUsernamesAndGroupnames(splitString[0], streamWriter);
                            }
                            else
                            {
                                streamWriter.WriteLine("<Unsuccess>");
                            }
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

        // lang nghe du lieu tu mot client cu the
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
                    // change the user's status in STATUS list to false
                    STATUS[username] = false;
                    // remove the TcpClient in CLIENT list after user's Logging Out successfully
                    CLIENT.Remove(username);

                    // send new online user signal to other clients
                    foreach (string user in USER.Keys)
                    {
                        if (user != username && STATUS[user] == true)
                        {
                            StreamWriter _streamWriter = new StreamWriter(CLIENT[user].GetStream());
                            _streamWriter.AutoFlush = true;
                            _streamWriter.WriteLine("<User_Off>");
                            _streamWriter.WriteLine(username);
                        }
                    }

                    // use to get the client's IP and client's port
                    IPEndPoint remoteIpEndPoint = _client.Client.RemoteEndPoint as IPEndPoint;
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

                    // check if the group's name exists
                    if (GROUP.ContainsKey(splitString[0]))
                    {
                        streamWriter.WriteLine("<Group_Exists>");
                        continue;
                    }

                    // check if the group's name is also a existed username
                    if (USER.ContainsKey(splitString[0]))
                    {
                        streamWriter.WriteLine("<Gr_Is_Usr>"); // Group_Name_Is_User_Name
                        continue;
                    }

                    // delete all leading and trailing white-spaces then add to userList
                    List<string> userList = new List<string>();
                    for (int i = 0; i < _username.Length; i++)
                    {
                        userList.Add(_username[i].Trim());
                    }

                    // finally, add all the things to the GROUP list
                    GROUP.Add(splitString[0], userList);

                    // send new group creation signal to other clients (include the client who creates the group)
                    foreach (string user in userList)
                    {
                        if (STATUS[user] == true)
                        {
                            StreamWriter _streamWriter = new StreamWriter(CLIENT[user].GetStream());
                            _streamWriter.AutoFlush = true;
                            _streamWriter.WriteLine("<Group_Created>");
                            _streamWriter.WriteLine(splitString[0]);
                        }
                    }

                    // update group's creation to status RTB
                    UpdateClientsStatusThreadSafe($"[{DateTime.Now}] {splitString[0]} group has been created with users: {splitString[1]}!\n");

                    continue;
                }

                // solve the image signal from client
                if (msgFromClient == "<Image>")
                {
                    string senderAndReceiverAndFilename = streamReader.ReadLine();
                    // splitString[0] is sender's username, splitString[1] is receiver's username or group's name
                    // splitString[2] is file's name
                    string[] splitString = senderAndReceiverAndFilename.Split('|');

                    // Thread.Sleep(10000);

                    // wait for client side to complete writing data
                    streamReader.BaseStream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(onImageRead), new object[] { streamReader, splitString[0], splitString[1], splitString[2] });

                    continue;
                }

                // solve the video signal from client
                if (msgFromClient == "<Video>")
                {
                    string senderAndReceiverAndFilenameAndFileExtension = streamReader.ReadLine();
                    // splitString[0] is sender's username, splitString[1] is receiver's username or group's name
                    // splitString[2] is file's name, splitString[3] is file's extension
                    string[] splitString = senderAndReceiverAndFilenameAndFileExtension.Split('|');

                    // Thread.Sleep(10000);

                    // wait for client side to complete writing data
                    streamReader.BaseStream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(onVideoRead), new object[] { streamReader, splitString[0], splitString[1], splitString[2], splitString[3] });

                    continue;
                }

                // solve the file signal from client
                if (msgFromClient == "<File>")
                {
                    string senderAndReceiverAndFilenameAndFileExtension = streamReader.ReadLine();
                    // splitString[0] is sender's username, splitString[1] is receiver's username or group's name
                    // splitString[2] is file's name, splitString[3] is file's extension
                    string[] splitString = senderAndReceiverAndFilenameAndFileExtension.Split('|');

                    // Thread.Sleep(10000);

                    // wait for client side to complete writing data
                    streamReader.BaseStream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(onFileRead), new object[] { streamReader, splitString[0], splitString[1], splitString[2], splitString[3] });

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
                            if (_client != CLIENT[user] && STATUS[user] == true)
                            {
                                StreamWriter receiverSW = new StreamWriter(CLIENT[user].GetStream());
                                receiverSW.AutoFlush = true;
                                receiverSW.WriteLine("<Message>");
                                receiverSW.WriteLine(senderAndReceiverAndMsg);
                            }
                        }
                    }

                    continue;
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
                statusAndMsg.Text += $"[{DateTime.Now}] Stop listening on port {portInput.Text}\n";
                listenBtn.Text = "Listen";
            }
            else
            {
                isServerRunning = true;
                Thread listenThread = new Thread(this.listen);
                listenThread.Start();
                listenThread.IsBackground = true;
                statusAndMsg.Text += $"[{DateTime.Now}] Start listening on port {portInput.Text}\n";
                listenBtn.Text = "Stop";
            }
        }

        private void sendOnlineUsernamesAndGroupnames(string username, StreamWriter streamWriter)
        {
            // send the online users and groups' name right after the client' connection
            streamWriter.WriteLine("<UaG_Name>"); // User_And_Group_Name
            string formatMsg = ""; // example format: "username1|username2|username3,groupname1|groupname2"
            foreach (string user in USER.Keys)
            {
                if (username != user && STATUS[user] == true)
                {
                    if (user != USER.Keys.Last())
                    {
                        formatMsg += user + "|";
                    }
                    else
                    {
                        formatMsg += user;
                    }
                }
            }
            formatMsg += ",";
            foreach (string group in GROUP.Keys)
            {
                if (group != GROUP.Keys.Last())
                {
                    formatMsg += group + "|";
                }
                else
                {
                    formatMsg += group;
                }
            }
            streamWriter.WriteLine(formatMsg);
        }

        private void onImageRead(IAsyncResult ar)
        {
            object[] objects = (object[])ar.AsyncState;
            StreamReader streamReader = (StreamReader)objects[0];
            string sender = (string)objects[1]; // splitString[0]
            string receiver = (string)objects[2]; // splitString[1]
            string fileName = (string)objects[3]; // splitString[2]

            int readBytes = streamReader.BaseStream.EndRead(ar);

            // if receiver's name is in CLIENT list, then do sending the message to it
            if (CLIENT.ContainsKey(receiver))
            {
                StreamWriter receiverSW = new StreamWriter(CLIENT[receiver].GetStream());
                receiverSW.AutoFlush = true;
                receiverSW.WriteLine("<Image>");
                receiverSW.WriteLine($"{sender}|{receiver}|{fileName}");
                Thread.Sleep(500); // wait for the client to receive two messages above
                receiverSW.BaseStream.BeginWrite(buffer, 0, readBytes, new AsyncCallback(onWrite), receiverSW);
            }
            else
            // if group's name is in GROUP list, then do sending the message to users in it
            if (GROUP.ContainsKey(receiver))
            {
                List<string> usersInGroup = GROUP[receiver];
                foreach (string user in usersInGroup)
                {
                    // only send if the... it's hard to say...
                    if (CLIENT[sender] != CLIENT[user] && STATUS[user] == true)
                    {
                        StreamWriter receiverSW = new StreamWriter(CLIENT[user].GetStream());
                        receiverSW.AutoFlush = true;
                        receiverSW.WriteLine("<Image>");
                        receiverSW.WriteLine($"{sender}|{receiver}|{fileName}");
                        Thread.Sleep(500); // wait for the client to receive two messages above
                        receiverSW.BaseStream.BeginWrite(buffer, 0, readBytes, new AsyncCallback(onWrite), receiverSW);
                    }
                }
            }
        }

        private void onVideoRead(IAsyncResult ar)
        {
            object[] objects = (object[])ar.AsyncState;
            StreamReader streamReader = (StreamReader)objects[0];
            string sender = (string)objects[1]; // splitString[0]
            string receiver = (string)objects[2]; // splitString[1]
            string fileName = (string)objects[3]; // splitString[2]
            string fileExtension = (string)objects[4]; // splitString[3]

            int readBytes = streamReader.BaseStream.EndRead(ar);

            // if receiver's name is in CLIENT list, then do sending the message to it
            if (CLIENT.ContainsKey(receiver))
            {
                StreamWriter receiverSW = new StreamWriter(CLIENT[receiver].GetStream());
                receiverSW.AutoFlush = true;
                receiverSW.WriteLine("<Video>");
                receiverSW.WriteLine($"{sender}|{receiver}|{fileName}|{fileExtension}");
                Thread.Sleep(500); // wait for the client to receive two messages above
                receiverSW.BaseStream.BeginWrite(buffer, 0, readBytes, new AsyncCallback(onWrite), receiverSW);
            }
            else
            // if group's name is in GROUP list, then do sending the message to users in it
            if (GROUP.ContainsKey(receiver))
            {
                List<string> usersInGroup = GROUP[receiver];
                foreach (string user in usersInGroup)
                {
                    // only send if the... it's hard to say...
                    if (CLIENT[sender] != CLIENT[user] && STATUS[user] == true)
                    {
                        StreamWriter receiverSW = new StreamWriter(CLIENT[user].GetStream());
                        receiverSW.AutoFlush = true;
                        receiverSW.WriteLine("<Video>");
                        receiverSW.WriteLine($"{sender}|{receiver}|{fileName}|{fileExtension}");
                        Thread.Sleep(500); // wait for the client to receive two messages above
                        receiverSW.BaseStream.BeginWrite(buffer, 0, readBytes, new AsyncCallback(onWrite), receiverSW);
                    }
                }
            }
        }

        private void onFileRead(IAsyncResult ar)
        {
            object[] objects = (object[])ar.AsyncState;
            StreamReader streamReader = (StreamReader)objects[0];
            string sender = (string)objects[1]; // splitString[0]
            string receiver = (string)objects[2]; // splitString[1]
            string fileName = (string)objects[3]; // splitString[2]
            string fileExtension = (string)objects[4]; // splitString[3]

            int readBytes = streamReader.BaseStream.EndRead(ar);

            // if receiver's name is in CLIENT list, then do sending the message to it
            if (CLIENT.ContainsKey(receiver))
            {
                StreamWriter receiverSW = new StreamWriter(CLIENT[receiver].GetStream());
                receiverSW.AutoFlush = true;
                receiverSW.WriteLine("<File>");
                receiverSW.WriteLine($"{sender}|{receiver}|{fileName}|{fileExtension}");
                Thread.Sleep(500); // wait for the client to receive two messages above
                receiverSW.BaseStream.BeginWrite(buffer, 0, readBytes, new AsyncCallback(onWrite), receiverSW);
            }
            else
            // if group's name is in GROUP list, then do sending the message to users in it
            if (GROUP.ContainsKey(receiver))
            {
                List<string> usersInGroup = GROUP[receiver];
                foreach (string user in usersInGroup)
                {
                    // only send if the... it's hard to say...
                    if (CLIENT[sender] != CLIENT[user] && STATUS[user] == true)
                    {
                        StreamWriter receiverSW = new StreamWriter(CLIENT[user].GetStream());
                        receiverSW.AutoFlush = true;
                        receiverSW.WriteLine("<File>");
                        receiverSW.WriteLine($"{sender}|{receiver}|{fileName}|{fileExtension}");
                        Thread.Sleep(500); // wait for the client to receive two messages above
                        receiverSW.BaseStream.BeginWrite(buffer, 0, readBytes, new AsyncCallback(onWrite), receiverSW);
                    }
                }
            }
        }

        private void onWrite(IAsyncResult ar)
        {
            StreamWriter streamWriter = (StreamWriter)ar.AsyncState;
            streamWriter.BaseStream.EndWrite(ar);
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