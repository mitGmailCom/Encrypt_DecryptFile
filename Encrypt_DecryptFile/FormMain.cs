using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encrypt_DecryptFile
{
    public partial class FormMain : Form
    {
        private string UserKey { get; set; } // key for crypt/decrypt
        private string Path { get; set; } // path to file, that it will be crypt/decrypt
        private long countBytesFile = 0; // number bytes in file, that it will be crypt/decrypt
        Byte[] data; // mass of bytes with data
        byte[] res1; // mass of bytes with data, that it will be crypt/decrypt
        Thread thread; // thread to start crypt/decrypt
        string str = null; // string with data, that it will be crypt/decrypt
        int countIter = 0; // number of bytes before click button "Cancel"

        private string dat { get; set; }
        public FormMain()
        {
            InitializeComponent();
            Load += FormMain_Load;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            btnStartProc.Enabled = false;
        }



        /// <summary>
        /// Open InputBox to input key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKey_Click(object sender, EventArgs e)
        {
            string value = "key123"; // default key
            InputBoxCreate.InputBox("Key", "Input Key(min length = 6 symbols)", ref value); // invoke InputBox(get key)
            UserKey = value; // save key
            MessageBox.Show("Don't forget your key, please!");
            // check all elements
            EnableBtnStartCrypt_Decrypt();
        }


        /// <summary>
        /// Select file to crypt/decrypt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            DefaultStateButtons();
            progressBarProcess.Value = 0;
            label1.Text = "val";
            trackBarSelectNumberSymb.Value = 6;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            ofd.InitialDirectory = @"C:\Users\Admin\Documents";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Path = ofd.FileName;
                label4.Text = Path.Substring(Path.LastIndexOf('\\') + 1);
                countBytesFile = CountBytesInFile();
                trackBarSelectNumberSymb.Maximum = ConvertToIntCountBytesFile();
            }
            // check all elements
            EnableBtnStartCrypt_Decrypt();
        }


        /// <summary>
        /// Save data to file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartProc_Click(object sender, EventArgs e)
        {
            if (radioBtnCrypt.Checked)
            {
                if (ClickCancel())
                    return;
                EnableButtonsInWrite();
                str = ReedDataFromFile();
                progressBarProcess.Maximum = str.Length; // set max progressBar
                thread = new Thread(new ThreadStart(InvokeEncode));
                thread.Start();

            }

            if (radioBtnDecrypt.Checked)
            {
                if (ClickCancel())
                    return;
                EnableButtonsInWrite();
                data = ReedBytesFromFile();
                progressBarProcess.Maximum = data.Length;
                thread = new Thread(new ThreadStart(InvokeDecode));
                thread.Start();
            }
        }

        #region For button "Go" (start process)
        /// <summary>
        /// Handler for case Decrypt
        /// </summary>
        private void InvokeDecode()
        {
            Decode(data, UserKey);
            StartThreadWriteData();
        }
        
        /// <summary>
        /// Handler for case Crypr
        /// </summary>
        private void InvokeEncode()
        {
            Encode(str, UserKey);
            StartThreadWriteData();
        }

        /// <summary>
        /// Start process Write to file
        /// </summary>
        private void StartThreadWriteData()
        {
            if (thread.ThreadState == ThreadState.Running)
            {
                Thread threadSecond = new Thread(WriteEncode);
                threadSecond.Start();
                threadSecond.Join();
            }
        }

        /// <summary>
        /// Write to file data
        /// </summary>
        private void WriteEncode()
        {
            string fileName = null;
            int numberBytesCount = 0;
            int currentBytesWrite = 0;
            byte[] tempMasBytes = new byte[1];
            if (radioBtnCrypt.Checked)
                fileName = "Encode.txt";
            if (radioBtnDecrypt.Checked)
                fileName = "Decode.txt";
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                numberBytesCount = countIter + 1;
                while (numberBytesCount > 0)
                {
                    tempMasBytes[0] = 0;  // clear mass
                    tempMasBytes[0] = res1[currentBytesWrite]; // set position to write
                    fs.Write(tempMasBytes, 0, 1); // write byte
                    numberBytesCount--;
                    currentBytesWrite++;
                }
            }
            Path = null;
            UserKey = null;
        }

        /// <summary>
        /// Case click Cancel
        /// </summary>
        /// <returns>Flag, is cancel click</returns>
        private bool ClickCancel()
        {
            bool isCancel = false;
            if (btnStartProc.Text == "Cancel")
            {
                thread.Abort();
                WriteEncode();
                DefaultStateButtons();
                MessageBox.Show("Data restoret to file!", "Info");
                progressBarProcess.Maximum = countIter + 1;
                label4.Text = "-";
                label1.Text = "val";
                trackBarSelectNumberSymb.Value = 6;
                progressBarProcess.Value = 0;
                Path = null;
                btnStartProc.Enabled = false;
                isCancel = true;
            }
            return isCancel;
        }
        #endregion



        #region ReedData
        /// <summary>
        /// Reed bytes from file
        /// </summary>
        /// <returns>String</returns>
        private string ReedDataFromFile()
        {
            data = new Byte[trackBarSelectNumberSymb.Value];
            FileStream fs = new FileStream(Path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 1024, FileOptions.Asynchronous);
            fs.BeginRead(data, 0, trackBarSelectNumberSymb.Value, ReadIsComplete, fs);
            return Encoding.UTF8.GetString(data).Remove(0, 1);
        }

        /// <summary>
        /// Reed bytes from file
        /// </summary>
        /// <returns>Mass bytes</returns>
        private byte[] ReedBytesFromFile()
        {
            data = new Byte[trackBarSelectNumberSymb.Value];
            FileStream fs = new FileStream(Path, FileMode.Open, FileAccess.Read, FileShare.Read, 1024, FileOptions.Asynchronous);
            fs.BeginRead(data, 0, trackBarSelectNumberSymb.Value, ReadIsComplete, fs);
            return data;
        }

        /// <summary>
        /// Method after Filestream (close stream)
        /// </summary>
        /// <param name="ar"></param>
        private void ReadIsComplete(IAsyncResult ar)
        {
            FileStream fs = (FileStream)ar.AsyncState;
            Int32 bytesRead = fs.EndRead(ar);
            fs.Close();
        }
        #endregion



        /// <summary>
        /// Get number of bytes in file in type Int
        /// </summary>
        /// <returns></returns>
        private int ConvertToIntCountBytesFile()
        {
            int res = 0;
            bool resToInt = ((Int32.TryParse(countBytesFile.ToString(), out res)));
            if (resToInt)
                trackBarSelectNumberSymb.Maximum = Convert.ToInt32(countBytesFile);
            else
                res = (int)countBytesFile;
            return res;
        }

        /// <summary>
        /// Calculate number of bytes in file, that user choosed
        /// </summary>
        private long CountBytesInFile()
        {
            long tempData = 0;
            if (Path != null || Path != string.Empty)
                using (FileStream fstream = File.OpenRead(Path))
                {
                    //countBytesFile = fstream.Length;
                    tempData = fstream.Length;
                }
            return tempData;
        }



        /// <summary>
        /// Set default state for buttons
        /// </summary>
        private void DefaultStateButtons()
        {
            btnKey.Text = "InputKey";
            btnStartProc.Text = "Go";
        }

        /// <summary>
        /// Enable buttons during process write data to file
        /// </summary>
        private void EnableButtonsInWrite()
        {
            //btnKey.Text = "Cancel";
            btnStartProc.Text = "Cancel";
        }

        /// <summary>
        /// Enable button Go
        /// </summary>
        private void EnableBtnStartCrypt_Decrypt()
        {
            // check all data for process crypt
            if (!HasEmptyFields())
                btnStartProc.Enabled = true;
        }

        /// <summary>
        /// Check all field that need to crypt
        /// </summary>
        /// <returns></returns>
        private bool HasEmptyFields()
        {
            // Fields to check
            //  - UserKey
            //  - RadioBtn - no
            //  - Path
            //  - NumberSymbReed
            bool res = false;
            if (UserKey == string.Empty || UserKey == null)
                res = true;
            if (Path == string.Empty || Path == null)
                res = true;
            if (trackBarSelectNumberSymb.Value == 0)
                res = true;

            return res;
        }

        #region  Changes of state elements
        private void radioBtnCrypt_CheckedChanged(object sender, EventArgs e)
        {
            // check all elements
            EnableBtnStartCrypt_Decrypt();
        }

        private void radioBtnDecrypt_CheckedChanged(object sender, EventArgs e)
        {
            // check all elements
            EnableBtnStartCrypt_Decrypt();
        }

        private void trackBarSelectNumberSymb_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBarSelectNumberSymb.Value.ToString();

            // check all elements
            EnableBtnStartCrypt_Decrypt();
        }
        #endregion




        #region Crypt/Decrypt file
        /// <summary>
        /// Crypt file
        /// </summary>
        /// <param name="pText"></param>
        /// <param name="pKey"></param>
        /// <returns></returns>
        public void Encode(string pText, string pKey)
        {
            byte[] txt = Encoding.Default.GetBytes(pText);
            byte[] key = Encoding.Default.GetBytes(pKey);
            res1 = new byte[pText.Length];
            for (int i = 0; i < txt.Length; i++)
            {
                res1[i] = (byte)(txt[i] ^ key[i % key.Length]);
                progressBarProcess.Invoke(new Action(() => progressBarProcess.Value = i+1));
                countIter = i;
            }
        }

        /// <summary>
        /// Decrypt file
        /// </summary>
        /// <param name="pText">Mass bytes that will decrypt</param>
        /// <param name="pKey">Key for decrypt</param>
        /// <returns></returns>
        public void Decode(byte[] pText, string pKey)
        {
            res1 = new byte[pText.Length];
            byte[] key = Encoding.Default.GetBytes(pKey);

            for (int i = 0; i < pText.Length; i++)
            {
                res1[i] = (byte)(pText[i] ^ key[i % key.Length]);
                progressBarProcess.Invoke(new Action(() => progressBarProcess.Value = i + 1));
                countIter = i;
            }
        }
        #endregion

    }
}
