using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConnectCsharpToMysql;
namespace Server
{
    public partial class DatabaseRestore : Form
    {
        public DatabaseRestore()
        {
            InitializeComponent();
        }

        private void btnDatabaseFileBrowser_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string FileName = openFileDialog1.FileName ;
                DBConnect.MysqlDatabaseFileRestore = FileName;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            DBConnect dbConnect = new DBConnect();
            dbConnect.Restore("siteinfo");
        }

       

       
    }
}
