using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using ConnectCsharpToMysql;
namespace Server
{
    public partial class ServerSetup : UserControl
    {

        #region Members

        public static bool HasStartup = false;

        #endregion

        public ServerSetup()
        {
            InitializeComponent();
        }

        #region ListBox item change functions

        /// <summary>
        /// Add the client address to lbxClient.
        /// </summary>
        /// <param name="IpEndPoint"></param>
        public void AddClient(IPEndPoint IpEndPoint)
        {
            lbxServer.BeginUpdate();
            if (lbxServer.Items.Count == 15)
            {
                lbxServer.Items.Clear();
            }
            lbxServer.Items.Add(IpEndPoint.ToString());
            lbxServer.EndUpdate();
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblServerStatus.Text = AsynchronousSocketListener.curMsg;
        }

       
        #region Button Event
        /// <summary>
        /// Start Server program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartup_Click(object sender, EventArgs e)
        {
            if (HasStartup == false)
            {
                try
                {
                    AsynchronousSocketListener.DataPort = tbxDataPort.Text; // Get Data Port
                    AsynchronousSocketListener.StatusPort = tbxStatusPort.Text;// Get Status Port
                    Trace.WriteLine("Getting Data Port and Status Port");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message);
                    return;
                }
                AsynchronousSocketListener.Server = this;
                backgroundWorker1.RunWorkerAsync();
                if (!backgroundWorker2.IsBusy)
                {
                    backgroundWorker2.RunWorkerAsync();
                }
                HasStartup = true;
                btnStartup.Enabled = false;
                btnStop.Enabled = true;

                
            }
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbxFolder.Text = folderBrowserDialog1.SelectedPath;
                AsynchronousSocketListener.saveFolder = folderBrowserDialog1.SelectedPath;
            }
            btnBrowser.Enabled = false;
            
            // create sub-folders to save data

            //CmdResult

            string path = AsynchronousSocketListener.saveFolder + "CmdResult";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            //Noise Data
            path = AsynchronousSocketListener.saveFolder + "\\NoiseData";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //RecorList
            path = AsynchronousSocketListener.saveFolder + "\\RecordList";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //Record MP3
            path = AsynchronousSocketListener.saveFolder + "\\RecordMP3";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //RecordOctave
            path = AsynchronousSocketListener.saveFolder + "\\RecordOctave";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            // RecordWECPNL
            path = AsynchronousSocketListener.saveFolder + "\\RecordWECPNL";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //backgroundWorker1.CancelAsync();
            AsynchronousSocketListener.suspend = true;
            btnStop.Enabled = false;
            btnRestart.Enabled = true;
        }


        private void btnRestart_Click(object sender, EventArgs e)
        {
            AsynchronousSocketListener.suspend = false;
            AsynchronousSocketListener.allDone.Set();
            btnStop.Enabled = true;
            btnRestart.Enabled = false;
        }

        public void btnStop_Enable()
        {
            btnStop.Enabled = true;
        }
        public void btnStop_Disable()
        {
            btnStop.Enabled = false;
        }

        public void btnStartup_Enable()
        {
            btnStartup.Enabled = true;
        }
        #endregion

        #region backgroundWorker

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            /// start a thread to listen on data port
            /// 
            BackgroundWorker bwAsync = sender as BackgroundWorker;
            
            AsynchronousSocketListener.StartListening(bwAsync,e);
        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            /// start a thread to listen on status port
            AsynchronousSocketListener.StartListening1();
        }

        #endregion

        

        



    }
}
