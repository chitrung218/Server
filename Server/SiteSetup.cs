using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConnectCsharpToMysql;
using System.Threading;
namespace Server
{
    public partial class SiteSetup : Form
    {
        #region Members
        private static string codeNumberDelete = null;
        private delegate void AddItemInListBox(string databaseName);
        private delegate void StriggerEventForPainting();
        #endregion
        public SiteSetup()
        {
            InitializeComponent();
        }

        private void SiteSetup_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'siteinfoDataSet1.clieninfo' table. You can move, or remove it, as needed.
            this.clieninfoTableAdapter1.Fill(this.siteinfoDataSet1.clieninfo);
            

        }

        // Add Button Event
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBConnect dbConnect = new DBConnect();

            if (tbxCode.Text == null)
            {
                MessageBox.Show("Missing Code");
                return;
            }
            else if (tbxSiteNum.Text == null)
            {
                MessageBox.Show("Missing Site Number");
                return;
            }
            else if (tbxSiteCode.Text == null)
            {
                MessageBox.Show("Mising Site Code");
                return;
            }
            else if (tbxIpAddress.Text == null)
            {
                MessageBox.Show("Missing IP Address");
                return;
            }
            dbConnect.InsertClientInfo("siteinfo", "clieninfo", tbxCode.Text, tbxSiteNum.Text, tbxSiteCode.Text , 0, tbxIpAddress.Text);
            
            // Create a database for the created Site
            Thread t = new Thread(() => dbConnect.CreateDatabaseActive("noisedata_" + tbxSiteCode.Text));
            t.IsBackground = true;
            t.Start();

            //FormReference.monitorPrefer.BeginInvoke(new StriggerEventForPainting(FormReference.monitorPrefer.AddEventIntoPaint)); 
            FormReference.monitorPrefer.BeginInvoke(new StriggerEventForPainting(FormReference.monitorPrefer.DrawIt)); 
            // Add database Name into the listbox in form ConnectDatabase
            FormReference.connDatabase.BeginInvoke(new AddItemInListBox(FormReference.connDatabase.AddDatabaseIntoListBox), tbxSiteCode.Text);
            
            
            // refresh database
            this.clieninfoTableAdapter1.Fill(this.siteinfoDataSet1.clieninfo);
        }

        //Cell click Event
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            codeNumberDelete = row.Cells[0].Value.ToString();
        }

        //Delete Button Event
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (codeNumberDelete == null)
            {
                MessageBox.Show("Please select the row you want to delete");
                return;
            }
            DBConnect dbConnect = new DBConnect();
            dbConnect.DeleteClient("siteinfo", "clieninfo", codeNumberDelete);
            codeNumberDelete = null;
            // refresh database
            this.clieninfoTableAdapter1.Fill(this.siteinfoDataSet1.clieninfo);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void RefreshDataGrid()
        {
            this.clieninfoTableAdapter1.Fill(this.siteinfoDataSet1.clieninfo);
        }

        private void timerCheckClientStatus_Tick(object sender, EventArgs e)
        {
            //DBConnect dbConnect = new DBConnect();
            //dbConnect.CheckStatusOfClients("siteinfo","clieninfo");
            RefreshDataGrid();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBConnect dbConnect = new DBConnect();
            dbConnect.Backup("siteinfo");
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DatabaseRestore dbRestore = new DatabaseRestore();
            //dbRestore.ShowDialog();

        }

       
        /*private string SelectDatabaseFile(string initialDirectory)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter =
               "txt files (*.sql)|*.sql|All files (*.*)|*.*";
            dialog.InitialDirectory = initialDirectory;
            dialog.Title = "Select a Database file";
            return (dialog.ShowDialog() == DialogResult.OK)
               ? dialog.FileName : null;
        }*/
       
    }
}
