using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using LiveLogViewer;
using System.Diagnostics;
using ConnectCsharpToMysql;
namespace Server
{
    public partial class ServerForm : Form
    {
        public static string DatabaseDumpFolder;
        public static string LogViewerPath = null;
        public ServerForm()
        {
            InitializeComponent();

            AsynchronousSocketListener.serverSendCommand = serverSendingCommand;
            FormReference.connDatabase = this.connectDatabse;
            FormReference.monitorPrefer = this.monitoring;
            AsynchronousSocketListener.remoteControlCommand = this.remoteControl;
            // Start the time of the system
            this.tbxTimeSystem.Text = DateTime.Now.ToString("hh:mm:ss");
            this.timer1.Enabled = true;

            // Set the color for monitoring of Sites
           
            //this.ovalShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            //this.ovalShape1.FillColor = Color.Red;
            //
            //this.label1.BringToFront();
        }

#region tabcontrol Event
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (tabControl1.SelectedIndex == 0)
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    this.serverSetup.Dock = DockStyle.Fill;
                    this.tabPage1.Controls.Add(serverSetup);
                }
            }*/
           /* else if (tabControl1.SelectedIndex == 1)
            {
                this.serverSendingCommand.Dock = DockStyle.Fill;
                this.tabPage2.Controls.Add(serverSendingCommand);
            }
            */
        }
#endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            //p.StartInfo.FileName = "C:\\Program Files\\ReflectSoftware\\ReflectInsight\\Bin\\ReflectInsight.exe";
            if (LogViewerPath != null)
            {
                p.StartInfo.FileName = LogViewerPath;
                p.Start();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Periodically update the values
            this.tbxTimeSystem.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            /*if (this.ovalShape1.FillColor == Color.Black)
            {
                this.ovalShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
                this.ovalShape1.FillColor = Color.Red;
            }*/
            /*else
            {
                this.ovalShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
                this.ovalShape1.FillColor = Color.Black;
            }*/
        }

        private void ovalShape1_Click(object sender, EventArgs e)
        {

        }

        private void tsbtnSiteSetup_Click(object sender, EventArgs e)
        {
            //SiteSetup siteSetup = new SiteSetup();
            //siteSetup.ShowDialog();
            if (!backgroundWorkerSiteSetup.IsBusy)
            {
                backgroundWorkerSiteSetup.RunWorkerAsync();
            }
            
        }

        private void backgroundWorkerSiteSetup_DoWork(object sender, DoWorkEventArgs e)
        {
            SiteSetup siteSetup = new SiteSetup();
            siteSetup.ShowDialog();
        }

        private void tsbtnPathSetup_Click(object sender, EventArgs e)
        {
            PathFolderSetup pathSetup = new PathFolderSetup();
            pathSetup.Show();
        }

        

        

       

        
        

    }
}
