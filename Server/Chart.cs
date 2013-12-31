using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConnectCsharpToMysql;
using MySql.Data.MySqlClient;
namespace Server
{
    public partial class Chart : Form
    {
        public Chart()
        {
            InitializeComponent();
        }

        private void Chart_Load(object sender, EventArgs e)
        {
            string query = "SELECT DateTime, LEQ5 FROM " + "data_20131108";
            DBConnect dbConnect = new DBConnect();
            dbConnect.setDatabase("noisedata_2826501");
            dbConnect.Initialize();
            if (dbConnect.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, dbConnect.getConnection());
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    this.chart1.DataBindTable(dataSource: dataReader, xField: "DateTime");
                }
                dataReader.Close();
               

            }
        }

        
    }
}
