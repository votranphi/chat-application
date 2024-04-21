using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.CognitiveServices.Speech;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Client
{
    public partial class ClientForm : Form
    {
        private TcpClient tcpClient;
        private string username;
        private bool isClientRunning;
        private StreamWriter streamWriter;
        private StreamReader streamReader;
        private delegate void SafeCallDelegate(string text);

        // maximum size of image is 100MB
        private static int buffer_size = 104857600;
        private byte[] buffer = new byte[buffer_size];

        public ClientForm(TcpClient tcpClient, string username)
        {
            this.tcpClient = tcpClient;
            this.username = username;
            isClientRunning = false;
            InitializeComponent();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            streamWriter = new StreamWriter(tcpClient.GetStream());
            streamReader = new StreamReader(tcpClient.GetStream());
            streamWriter.AutoFlush = true;

            this.Text = $"{username}'s ClientForm";

            isClientRunning = true;
            Thread clientThread = new Thread(() => receiveFromServer());
            clientThread.Start();
            clientThread.IsBackground = true;
        }

        // lang nghe du lieu tu server
        private void receiveFromServer() // always running
        {
            while (isClientRunning)
            {
                string msgFromServer = streamReader.ReadLine();

                // receive the online usernames and groupnames then update it to DataGridView
                if (msgFromServer == "<UaG_Name>")
                {
                    string formatMsg = streamReader.ReadLine();
                    string usernames = formatMsg.Split(',')[0];
                    string groupnames = formatMsg.Split(',')[1];

                    foreach (string user in usernames.Split('|'))
                    {
                        if (user != "")
                        {
                            UpdateOnlineUserDataGridViewThreadSafe(user);
                        }
                    }
                    foreach (string group in groupnames.Split('|'))
                    {
                        if (group != "")
                        {
                            UpdateGroupDataGridViewThreadSafe(group);
                        }
                    }
                }

                // receive messages from other clients
                if (msgFromServer == "<Message>")
                {
                    string senderAndMsg = streamReader.ReadLine();
                    // splitString[0] is sender's username, splitString[1] is username or group's name, splitStrin[2] is message
                    string[] splitString = senderAndMsg.Split('|');

                    // update the received message to the RichTextBox
                    AppendRichTextBox(splitString[0], splitString[1], splitString[2], "");

                    continue;
                }

                // receive images from other clients
                if (msgFromServer == "<Image>")
                {
                    string senderAndFilenameAndFileExtension = streamReader.ReadLine();
                    // splitString[0] is sender's name, splitString[1] is file's name, splitString[2] is file's extension
                    string[] splitString = senderAndFilenameAndFileExtension.Split('|');

                    // Thread.Sleep(10000);

                    streamReader.BaseStream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(onImageRead), new object[] { streamReader, splitString[1], splitString[2] });

                    // update the received message to the RichTextBox
                    AppendRichTextBox(splitString[0], username, $"Sent {username} an image. Waiting for image's opening...", "");

                    continue;
                }

                // receive videos from other clients
                if (msgFromServer == "<Video>")
                {
                    string senderAndFilenameAndFileExtension = streamReader.ReadLine();
                    // splitString[0] is sender's name, splitString[1] is file's name, splitString[2] is file's extension
                    string[] splitString = senderAndFilenameAndFileExtension.Split('|');

                    // Thread.Sleep(10000);

                    streamReader.BaseStream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(onVideoRead), new object[] { streamReader, splitString[1], splitString[2] });

                    // update the received message to the RichTextBox
                    AppendRichTextBox(splitString[0], username, $"Sent {username} a video. Waiting for video's opening...", "");

                    continue;
                }

                // receive Files from other clients
                if (msgFromServer == "<File>")
                {
                    string senderAndFilenameAndFileExtension = streamReader.ReadLine();
                    // splitString[0] is sender's name, splitString[1] is file's name, splitString[2] is file's extension
                    string[] splitString = senderAndFilenameAndFileExtension.Split('|');

                    // Thread.Sleep(10000);

                    streamReader.BaseStream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(onFileRead), new object[] { streamReader, splitString[1], splitString[2] });

                    // update the received message to the RichTextBox
                    AppendRichTextBox(splitString[0], username, $"Sent {username} a *{splitString[2]} file. Waiting for file's opening...", "");

                    continue;
                }

                // update the online user data grid view if a user logged in or signed up
                if (msgFromServer == "<User_Onl>")
                {
                    string onlineUsername = streamReader.ReadLine();
                    UpdateOnlineUserDataGridViewThreadSafe(onlineUsername);
                    continue;
                }

                // update the online user data grid view if a user logged out
                if (msgFromServer == "<User_Off>")
                {
                    string offlineUsername = streamReader.ReadLine();
                    UpdateOfflineUserDataGridViewThreadSafe(offlineUsername);
                    continue;
                }

                // update the group data grid view if a group is created
                if (msgFromServer == "<Group_Created>")
                {
                    string groupName = streamReader.ReadLine();
                    UpdateGroupDataGridViewThreadSafe(groupName);
                    continue;
                }

                // 
                if (msgFromServer == "<Group_Exists>")
                {
                    MessageBox.Show("Group existed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            streamWriter.WriteLine("<Logout>");

            isClientRunning = false;

            new Thread(() => Application.Run(new LoginForm())).Start();
            this.Close();
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            // exceptions catching
            if (msgToSend.Text == "")
            {
                MessageBox.Show("Empty Fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tbReceiver.Text == username)
            {
                MessageBox.Show("Cannot send message to yourself!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tbReceiver.Text == "")
            {
                MessageBox.Show("Please select an user or a group!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // implementation
            streamWriter.WriteLine("<Message>");
            streamWriter.WriteLine($"{username}|{tbReceiver.Text}|{msgToSend.Text}");

            // update the sent message to RichTextBox
            AppendRichTextBox(username, tbReceiver.Text, msgToSend.Text, "");

            msgToSend.Text = "";
        }

        private void msgToSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (sendBtn.Enabled)
                {
                    sendBtn_Click(sender, e);
                }
            }
        }

        private void imageBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image file|*.jpg;*.png;*.jpeg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // convert image from OFD to byte array (image file to base64String)
                byte[] bytes = File.ReadAllBytes(ofd.FileName);
                FileInfo fi = new FileInfo(ofd.FileName);

                // update to RichTextBox
                AppendRichTextBox(username, tbReceiver.Text, $"Sent {tbReceiver.Text} an image", "");

                // send the signal message and byte array to server
                streamWriter.WriteLine("<Image>");
                streamWriter.WriteLine($"{username}|{tbReceiver.Text}|{fi.Name}|{fi.Extension}");
                Thread.Sleep(500); // wait for the server to receive two messages above
                streamWriter.BaseStream.BeginWrite(bytes, 0, bytes.Length, new AsyncCallback(onWrite), streamWriter);
            }
        }

        private void btnVideo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Video files|*.mp4;*.mov;*.avi;*.wmv;*.m4a";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // convert image from OFD to byte array (image file to base64String)
                byte[] bytes = File.ReadAllBytes(ofd.FileName);
                FileInfo fi = new FileInfo(ofd.FileName);

                // update to RichTextBox
                AppendRichTextBox(username, tbReceiver.Text, $"Sent {tbReceiver.Text} a video", "");

                // send the signal message and byte array to server
                streamWriter.WriteLine("<Video>");
                streamWriter.WriteLine($"{username}|{tbReceiver.Text}|{fi.Name}|{fi.Extension}");
                Thread.Sleep(500); // wait for the server to receive two messages above
                streamWriter.BaseStream.BeginWrite(bytes, 0, bytes.Length, new AsyncCallback(onWrite), streamWriter);
            }
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All files|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // convert image from OFD to byte array (image file to base64String)
                byte[] bytes = File.ReadAllBytes(ofd.FileName);
                FileInfo fi = new FileInfo(ofd.FileName);

                // update to RichTextBox
                AppendRichTextBox(username, tbReceiver.Text, $"Sent {tbReceiver.Text} a *{fi.Extension} file", "");

                // send the signal message and byte array to server
                streamWriter.WriteLine("<File>");
                streamWriter.WriteLine($"{username}|{tbReceiver.Text}|{fi.Name}|{fi.Extension}");
                Thread.Sleep(500); // wait for the server to receive two messages above
                streamWriter.BaseStream.BeginWrite(bytes, 0, bytes.Length, new AsyncCallback(onWrite), streamWriter);
            }
        }

        private void emojiCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            msgToSend.Text += emojiCB.Text;
            emojiCB.SelectedIndex = -1;
        }

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            new Thread(() => Application.Run(new CreateGroupForm(tcpClient, username))).Start();
        }

        private void dgvUser_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUser.SelectedCells.Count == 1)
            {
                tbReceiver.Text = dgvUser.SelectedCells[0].Value.ToString();
            }
            dgvGroup.ClearSelection();
        }

        private void dgvGroup_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGroup.SelectedCells.Count == 1)
            {
                tbReceiver.Text = dgvGroup.SelectedCells[0].Value.ToString();
            }
            dgvUser.ClearSelection();
        }

        private async void btnVoice_Click(object sender, EventArgs e)
        {
            btnVoice.BackColor = Color.MediumSeaGreen;

            var speechConfig = SpeechConfig.FromSubscription("f4e31e13b7a74b88b24ac20196052dfe", "southeastasia");
            speechConfig.SpeechRecognitionLanguage = "vi-VN";

            using var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
            using var speechRecognizer = new SpeechRecognizer(speechConfig, audioConfig);

            // Console.WriteLine("Speak into your microphone.");
            var speechRecognitionResult = await speechRecognizer.RecognizeOnceAsync();
            OutputSpeechRecognitionResult(speechRecognitionResult);

            btnVoice.BackColor = Color.CornflowerBlue;
        }

        private void onImageRead(IAsyncResult ar)
        {
            object[] objects = (object[])ar.AsyncState;
            StreamReader sr = (StreamReader)objects[0];
            string fileName = (string)objects[1];
            string fileExtension = (string)objects[2];

            int readBytes = sr.BaseStream.EndRead(ar);

            // create a new ImageViewForm to display the picture
            new Thread(() => Application.Run(new ImageViewForm(buffer, readBytes, username, fileName, fileExtension))).Start();
        }

        private void onVideoRead(IAsyncResult ar)
        {
            object[] objects = (object[])ar.AsyncState;
            StreamReader sr = (StreamReader)objects[0];
            string fileName = (string)objects[1];
            string fileExtension = (string)objects[2];

            int readBytes = sr.BaseStream.EndRead(ar);

            // create a new ImageViewForm to display the picture
            new Thread(() => Application.Run(new VideoViewForm(buffer, readBytes, username, fileName, fileExtension))).Start();
        }

        private void onFileRead(IAsyncResult ar)
        {
            object[] objects = (object[])ar.AsyncState;
            StreamReader sr = (StreamReader)objects[0];
            string fileName = (string)objects[1];
            string fileExtension = (string)objects[2];

            int readBytes = sr.BaseStream.EndRead(ar);

            // create a new ImageViewForm to display the picture
            new Thread(() => Application.Run(new FileViewForm(buffer, readBytes, username, fileName, fileExtension))).Start();
        }

        private void onWrite(IAsyncResult ar)
        {
            StreamWriter streamWriter = (StreamWriter)ar.AsyncState;

            streamWriter.BaseStream.EndWrite(ar);
        }

        private void OutputSpeechRecognitionResult(SpeechRecognitionResult speechRecognitionResult)
        {
            switch (speechRecognitionResult.Reason)
            {
                case ResultReason.RecognizedSpeech:
                    msgToSend.Text += speechRecognitionResult.Text;
                    break;
                case ResultReason.NoMatch:
                    MessageBox.Show("NOMATCH: Speech could not be recognized.");
                    break;
                case ResultReason.Canceled:
                    var cancellation = CancellationDetails.FromResult(speechRecognitionResult);
                    MessageBox.Show($"CANCELED: Reason={cancellation.Reason}");

                    if (cancellation.Reason == CancellationReason.Error)
                    {
                        MessageBox.Show($"CANCELED: ErrorCode={cancellation.ErrorCode}\nCANCELED: ErrorDetails={cancellation.ErrorDetails}\nCANCELED: Did you set the speech resource key and region values?");
                    }
                    break;
            }
        }

        // the method use to format the message then update it to RichTextBox
        private void AppendRichTextBox(string sender, string receiver, string message, string link)
        {
            statusAndMsg.BeginInvoke(new MethodInvoker(() =>
            {
                Font currentFont = statusAndMsg.SelectionFont;

                //Username
                statusAndMsg.SelectionStart = statusAndMsg.TextLength;
                statusAndMsg.SelectionLength = 0;
                statusAndMsg.SelectionColor = Color.Red;
                statusAndMsg.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, FontStyle.Bold);
                statusAndMsg.AppendText(sender + "<" + receiver + ">");
                statusAndMsg.SelectionColor = statusAndMsg.ForeColor;

                statusAndMsg.AppendText(": ");

                //Message
                statusAndMsg.SelectionStart = statusAndMsg.TextLength;
                statusAndMsg.SelectionLength = 0;
                statusAndMsg.SelectionColor = Color.Green;
                statusAndMsg.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, FontStyle.Regular);
                statusAndMsg.AppendText(message);
                statusAndMsg.SelectionColor = statusAndMsg.ForeColor;

                statusAndMsg.AppendText(" ");

                //link
                statusAndMsg.SelectionStart = statusAndMsg.TextLength;
                statusAndMsg.SelectionLength = 0;
                statusAndMsg.SelectionColor = Color.Blue;
                statusAndMsg.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, FontStyle.Underline);
                statusAndMsg.AppendText(link);
                statusAndMsg.SelectionColor = statusAndMsg.ForeColor;


                statusAndMsg.SelectionStart = statusAndMsg.GetFirstCharIndexOfCurrentLine();
                statusAndMsg.SelectionLength = 0;

                if (sender == this.username)
                {
                    statusAndMsg.SelectionAlignment = HorizontalAlignment.Right;
                }
                else statusAndMsg.SelectionAlignment = HorizontalAlignment.Left;

                statusAndMsg.AppendText(Environment.NewLine);
            }));
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        #region UpdateThreadSafe

        private void UpdateOnlineUserDataGridViewThreadSafe(string text)
        {
            if (statusAndMsg.InvokeRequired)
            {
                var d = new SafeCallDelegate(UpdateOnlineUserDataGridViewThreadSafe);
                dgvUser.Invoke(d, new object[] { text });
            }
            else
            {
                dgvUser.Rows.Add(text);
            }
        }

        private void UpdateOfflineUserDataGridViewThreadSafe(string text)
        {
            if (statusAndMsg.InvokeRequired)
            {
                var d = new SafeCallDelegate(UpdateOfflineUserDataGridViewThreadSafe);
                dgvUser.Invoke(d, new object[] { text });
            }
            else
            {
                foreach (DataGridViewRow row in dgvUser.Rows)
                {
                    if (row.Cells[0].Value.ToString() == text)
                    {
                        dgvUser.Rows.RemoveAt(row.Index);
                        break;
                    }
                }
            }
        }

        private void UpdateGroupDataGridViewThreadSafe(string text)
        {
            if (statusAndMsg.InvokeRequired)
            {
                var d = new SafeCallDelegate(UpdateGroupDataGridViewThreadSafe);
                dgvGroup.Invoke(d, new object[] { text });
            }
            else
            {
                dgvGroup.Rows.Add(text);
            }
        }

        #endregion
    }
}