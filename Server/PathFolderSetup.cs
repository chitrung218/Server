using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ConnectCsharpToMysql;
namespace Server
{
    public partial class PathFolderSetup : Form
    {
        public PathFolderSetup()
        {
            InitializeComponent();
        }

        private void btnDatabaseBackupBrowser_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDatabaseBackup.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbxDatabaseBackup.Text = folderBrowserDatabaseBackup.SelectedPath;
                
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (tbxDatabaseBackup.Text.ToString() != null)
            {
                ServerForm.DatabaseDumpFolder = tbxDatabaseBackup.Text;
                if (!Directory.Exists(ServerForm.DatabaseDumpFolder))
                {
                    Directory.CreateDirectory(ServerForm.DatabaseDumpFolder);
                }
            }
            if (tbxLogViewer.Text != null)
            {
                ServerForm.LogViewerPath = tbxLogViewer.Text;
            }
            if (tbxMysqlDump.Text != null)
            {
                DBConnect.MysqlDumpPath = tbxMysqlDump.Text;
            }
            if (tbxMysql.Text != null)
            {
                DBConnect.MysqlPath = tbxMysql.Text;
            }
            if (tbxData.Text != null)
            {
                AsynchronousSocketListener.saveFolder = tbxData.Text;
                string path;
                path = tbxData.Text + "CmdResult";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //Noise Data
                path = tbxData.Text + "\\NoiseData";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //RecorList
                path = tbxData.Text + "\\RecordList";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //Record MP3
                path = tbxData.Text + "\\RecordMP3";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //RecordOctave
                path = tbxData.Text + "\\RecordOctave";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // RecordWECPNL
                path = tbxData.Text + "\\RecordWECPNL";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
                
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDataBrowser_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserData.ShowDialog();
            if (result == DialogResult.OK)
            {
                //tbxDatabaseBackup.Text = folderBrowserDatabaseBackup.SelectedPath;
                tbxData.Text = folderBrowserData.SelectedPath;
                
            }
            
        }

        private void btnLogViewerBrowser_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserLogViewer.ShowDialog();
            if (result == DialogResult.OK)
            {
                //tbxDatabaseBackup.Text = folderBrowserDatabaseBackup.SelectedPath;
                tbxLogViewer.Text = folderBrowserLogViewer.SelectedPath;

            }
        }

        private void btnMysqlDumpBrowser_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserMysqlDump.ShowDialog();
            if (result == DialogResult.OK)
            {
                //tbxDatabaseBackup.Text = folderBrowserDatabaseBackup.SelectedPath;
                tbxMysqlDump.Text = folderBrowserMysqlDump.SelectedPath;

            }
        }

        private void btnMysqlBrowser_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserMysql.ShowDialog();
            if (result == DialogResult.OK)
            {
                //tbxDatabaseBackup.Text = folderBrowserDatabaseBackup.SelectedPath;
                tbxMysql.Text = folderBrowserMysql.SelectedPath;

            }
        }
    }
}
