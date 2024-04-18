using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientForm : Form
    {
        private TcpClient tcpClient;
        private Thread clientThread;
        private bool isClientRunning = false;
        private StreamWriter streamWriter;
        private StreamReader streamReader;
        private delegate void SafeCallDelegate(string text);
        private delegate void SafeCallDelegateImage(Bitmap bmp);
        // List<Image> imageList = new List<Image>();

        public ClientForm()
        {
            InitializeComponent();
        }

        private void receiveFromServer() // always running
        {
            streamReader = new StreamReader(tcpClient.GetStream());
            try
            {
                while (isClientRunning)
                {
                    string msg = streamReader.ReadLine();

                    if (msg == "<Invalid_Username_Exists>")
                    {
                        UpdateChatHistoryThreadSafe($"Username already exists, please pick another one!\n");
                        isClientRunning = false;
                        UpdateConnectButtonTextThreadSafe("Connect");
                        break;
                    }
                    if (msg == "<Accepted>")
                    {
                        UpdateChatHistoryThreadSafe($"[{DateTime.Now}] Connected to the server with ip address {ipInput.Text} on port {portInput.Text}\n");
                        continue;
                    }

                    if (msg == "<Image>")
                    {
                        // maximum size of image is 524288 bytes
                        byte[] bytes = new byte[524288];
                        // wait for server side to complete writing data
                        Thread.Sleep(1000);
                        streamReader.BaseStream.Read(bytes, 0, bytes.Length);

                        // byte array to image (base64String to image file)
                        Bitmap bmp;
                        using (var ms = new MemoryStream(bytes))
                        {
                            bmp = new Bitmap(ms);
                        }

                        // upload the file to the chat box -> upload the file to new dialog
                        UpdateImageThreadSafe(bmp);

                        continue;
                    }

                    // the if... below resolves the Problem 1 in ServerForm.cs
                    if (msg != null && msg != "")
                    {
                        UpdateChatHistoryThreadSafe($"{msg}\n");
                    }
                }
            }
            catch (SocketException sockEx)
            {
                tcpClient.Close();
                streamReader.Close();
            }
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (isClientRunning)
                {
                    isClientRunning = false;
                    streamWriter.WriteLine("<Disconnect>");
                    tcpClient = null;
                    statusAndMsg.Text += $"[{DateTime.Now}] Disconnected from the server with ip address {ipInput.Text} on port {portInput.Text}\n";
                    connectBtn.Text = "Connect";
                }
                else
                {
                    isClientRunning = true;
                    tcpClient = new TcpClient();
                    tcpClient.Connect(new IPEndPoint(IPAddress.Parse(ipInput.Text), int.Parse(portInput.Text)));
                    streamWriter = new StreamWriter(tcpClient.GetStream());
                    streamWriter.AutoFlush = true;

                    streamWriter.WriteLine(usernameInput.Text);

                    clientThread = new Thread(this.receiveFromServer);
                    clientThread.Start();
                    connectBtn.Text = "Disconnect";
                }
            }
            catch (SocketException sockEx)
            {
                MessageBox.Show(sockEx.Message, "Network error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                isClientRunning = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (tcpClient != null && tcpClient.Connected)
                {
                    streamWriter.WriteLine(msgToSend.Text);
                    statusAndMsg.Text += $"[{DateTime.Now}] {usernameInput.Text}: {msgToSend.Text}\n";
                    msgToSend.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void emoBtn_Click(object sender, EventArgs e)
        {
            msgToSend.Focus();
        }

        private void imageBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image file|*.jpg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // convert image from OFD to byte array (image file to base64String)
                Image image = Image.FromFile(ofd.FileName);
                var ms = new MemoryStream();
                image.Save(ms, image.RawFormat);
                byte[] bytes = ms.ToArray();

                streamWriter.WriteLine("<Image>");
                streamWriter.BaseStream.Write(bytes, 0, bytes.Length);
            }
        }

        private void emojiCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            msgToSend.Text += emojiCB.Text;
            emojiCB.SelectedIndex = -1;
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

        private void UpdateConnectButtonTextThreadSafe(string text)
        {
            if (connectBtn.InvokeRequired)
            {
                var d = new SafeCallDelegate(UpdateConnectButtonTextThreadSafe);
                connectBtn.Invoke(d, new object[] { text });
            }
            else
            {
                connectBtn.Text = text;
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
                statusAndMsg.Text += "\n";
                // move cursor to the end of the RTB
                statusAndMsg.Select(statusAndMsg.Text.Length - 1, 0);
                // scroll to cursor the RTB
                statusAndMsg.ScrollToCaret();

                Clipboard.SetDataObject(bmp);
                statusAndMsg.Paste();
            }
        }

        #region Responsive

        private void ipInput_TextChanged(object sender, EventArgs e)
        {
            if (ipInput.Text != "" && portInput.Text != "" && usernameInput.Text != "")
            {
                connectBtn.Enabled = true;
            }
            else
            {
                connectBtn.Enabled = false;
            }
        }

        private void portInput_TextChanged(object sender, EventArgs e)
        {
            if (ipInput.Text != "" && portInput.Text != "" && usernameInput.Text != "")
            {
                connectBtn.Enabled = true;
            }
            else
            {
                connectBtn.Enabled = false;
            }
        }

        private void usernameInput_TextChanged(object sender, EventArgs e)
        {
            if (ipInput.Text != "" && portInput.Text != "" && usernameInput.Text != "")
            {
                connectBtn.Enabled = true;
            }
            else
            {
                connectBtn.Enabled = false;
            }
        }

        private void connectBtn_TextChanged(object sender, EventArgs e)
        {
            if (connectBtn.Text == "Connect")
            {
                ipInput.Enabled = true;
                portInput.Enabled = true;
                usernameInput.Enabled = true;
                imageBtn.Enabled = false;
            }
            else
            {
                ipInput.Enabled = false;
                portInput.Enabled = false;
                usernameInput.Enabled = false;
                imageBtn.Enabled = true;
            }
        }

        private void msgToSend_TextChanged(object sender, EventArgs e)
        {
            if (msgToSend.Text == "")
            {
                sendBtn.Enabled = false;
            }
            else
            {
                if (connectBtn.Text == "Connect")
                {
                    sendBtn.Enabled = false;
                }
                else
                {
                    sendBtn.Enabled = true;
                }
            }
        }

        #endregion
    }
}