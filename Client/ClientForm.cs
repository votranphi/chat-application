using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

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
        private delegate void SafeCallDelegateImage(Bitmap bmp);

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

        private void receiveFromServer() // always running
        {
            

            while (isClientRunning)
            {
                string msgFromServer = streamReader.ReadLine();

                // solve the image sending message from server
                if (msgFromServer == "<Image>")
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

                if (msgFromServer == "<Message>")
                {
                    string msg = streamReader.ReadLine();
                    UpdateChatHistoryThreadSafe(msg + "\n");
                    continue;
                }

                if (msgFromServer == "<UoG_Not_Exist>")
                {
                    MessageBox.Show("Username or group's name doesn't exist!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (tbDestination.Text == username)
            {
                MessageBox.Show("Cannot send message to yourself!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // implementation
            streamWriter.WriteLine("<Message>");
            streamWriter.WriteLine(tbDestination.Text);
            streamWriter.WriteLine(msgToSend.Text);

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

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            CreateGroupForm createGroupForm = new CreateGroupForm();
            createGroupForm.ShowDialog();
        }

        #region UpdateThreadSafe

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
                statusAndMsg.Text += "\n";
                // move cursor to the end of the RTB
                statusAndMsg.Select(statusAndMsg.Text.Length - 1, 0);
                // scroll to cursor the RTB
                statusAndMsg.ScrollToCaret();

                Clipboard.SetDataObject(bmp);
                statusAndMsg.Paste();
            }
        }

        #endregion
    }
}