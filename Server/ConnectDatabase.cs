using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConnectCsharpToMysql;
using System.IO;
using System.Threading;
namespace Server
{
    
    public partial class ConnectDatabase : UserControl
    {
        private static DBConnect dbConnect;

       

        public ConnectDatabase()
        {
            InitializeComponent();
        }

        

        private void btnConnect_Click(object sender, EventArgs e)
        {
            dbConnect = new DBConnect();
            
            //dbConnect.setDatabase(lbxDatabase.SelectedItem.ToString());
            dbConnect.setServer(tbxServer.Text);
            dbConnect.setUsername(tbxUsername.Text);
            dbConnect.setPassword(tbxPassword.Text);
            //dbConnect.Initialize();
            btnSelect.Enabled = true;
            timerCheckClientStatus.Enabled = true;

            //Create database to record information of sites
            //DBConnect dbConnect = new DBConnect();
            Thread t = new Thread(() => dbConnect.CreateDatabaseActive("siteinfo"));
            t.IsBackground = true;
            t.Name = "Create database siteinfo";
            t.Start();

            List<string> list;
            list = dbConnect.GetAllSiteCode("siteinfo", "clieninfo");
            foreach (string itemList in list)
            {
                lbxDatabase.Items.Add("noisedata_" + itemList);

            }
          
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lbxDatabase.SelectedIndex == -1)
            {
                MessageBox.Show("please select database first and try again");
                return;
            }
            dbConnect.setDatabase(lbxDatabase.SelectedItem.ToString());
            dbConnect.Initialize();
            string date ;
            string month;
            if (nUPDate.Value < 10)
            {
                date = "0" + nUPDate.Value.ToString();
            }
            else
            {
                date = nUPDate.Value.ToString();
            }
            if (nUPMonth.Value < 10)
            {
                month = "0" + nUPMonth.Value.ToString();
            }
            else
            {
                month = nUPMonth.Value.ToString();
            }
            
            string year = nUPYear.Value.ToString();
            string queryTable = "data_" + year + month + date;
            bool tableExist = dbConnect.CheckTableExist(lbxDatabase.SelectedItem.ToString(), queryTable);
            if (tableExist == false)
            {
                return;
            }
            List<string>[] list;
            list = dbConnect.Select(queryTable);
            DatabaseData.listData = list;
            DatabaseData dbData = new DatabaseData();
            dbData.showData();
            dbData.Show();
             



            
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //dbConnect.create_Tbactive("noisedata_2826501","testtable3");
            dbConnect.CheckTableExist("noisedata_2826501", "testtable3");
        }

        // just testing
        private void button1_Click(object sender, EventArgs e)
        {
            bool exist =  dbConnect.CheckDatabaseExist("siteinfo1");
            dbConnect.CreateDatabaseActive("SiteInfo");
            //dbConnect.Insert("noisedata_2826501", "data_20131108", "10:30:00", 7.5, 8.0, 9.0);

            //List<string> list = new List<string>();
            //string filePath = "C:\\Users\\Chi Trung\\Desktop\\test\\NoiseData\\2826501\\20131108\\20131108001500.dat";
            //RecordDataIntoDatabase(filePath);
            //Chart chart = new Chart();
           // chart.Show();
            //SendingCommand.GetClientClode("203.250.78.204");
           /* int lineNumber = 0;
            byte[] DateTime_Buf = null;
            string temp_Hour;
            string temp_Minute;
            string temp_Second;
            string temp_DateTime = "00:00:00";
            double LEQ5= 0;
            string StrLEQ5;
            byte[] LEQ5_Buf;
            double MAX = 0;
            string StrMAX;
            byte[] MAX_Buf;
            double MIN =0;
            string StrMIN;
            byte[] MIN_Buf;
            using (StreamReader reader = new StreamReader("C:\\Users\\Chi Trung\\Desktop\\test\\NoiseData\\2826501\\20131108\\20131108001000.dat"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;
                    if (lineNumber == 3)
                    {
                        DateTime_Buf = Encoding.ASCII.GetBytes(line);
                        temp_Hour = Encoding.UTF8.GetString(DateTime_Buf, 13, 2);
                        temp_Minute = Encoding.UTF8.GetString(DateTime_Buf, 15, 2);
                        temp_Second = Encoding.UTF8.GetString(DateTime_Buf, 17, 2);
                        temp_DateTime = temp_Hour + ":" + temp_Minute + ":" + temp_Second;
                    }
                    if (lineNumber == 4)
                    {
                        LEQ5_Buf = Encoding.ASCII.GetBytes(line);
                        StrLEQ5 = Encoding.UTF8.GetString(LEQ5_Buf, 5, 5);
                        LEQ5 = Convert.ToDouble(StrLEQ5);
                    }
                    if (lineNumber == 5)
                    {
                        MAX_Buf = Encoding.ASCII.GetBytes(line);
                        StrMAX = Encoding.UTF8.GetString(MAX_Buf, 4, 5);
                        MAX = Convert.ToDouble(StrMAX);
                    }
                    if (lineNumber == 6)
                    {
                        MIN_Buf = Encoding.ASCII.GetBytes(line);
                        StrMIN = Encoding.UTF8.GetString(MIN_Buf, 4, 5);
                        MIN = Convert.ToDouble(StrMIN);
                        break;
                    }
                }
            }//using
            dbConnect.Insert("noisedata_2826501", "data_20131108", temp_DateTime, LEQ5, MAX, MIN);*/
        }//method

       // Record noise data into database

        public static void RecordDataIntoDatabase(string filePath)
        {
            int lineNumber = 0;
            byte[] DateTime_Buf = null;
            string temp_Hour;
            string temp_Minute;
            string temp_Second;
            string temp_DateTime = "00:00:00";
            double LEQ5 = 0;
            string StrLEQ5;
            byte[] LEQ5_Buf;
            double MAX = 0;
            string StrMAX;
            byte[] MAX_Buf;
            double MIN = 0;
            string StrMIN;
            byte[] MIN_Buf;

            byte[] temp_buf;
            string temp_Str;
            string database = null;
            string table = null;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;
                    if (lineNumber == 2)
                    {
                        temp_buf = Encoding.ASCII.GetBytes(line);
                        temp_Str = Encoding.UTF8.GetString(temp_buf, 5, 7);
                        database = "noisedata_" + temp_Str;
                        
                    }
                    if (lineNumber == 3)
                    {
                        DateTime_Buf = Encoding.ASCII.GetBytes(line);
                        temp_Str = Encoding.UTF8.GetString(DateTime_Buf, 5, 8);
                        table = "data_" + temp_Str;
                        temp_Hour = Encoding.UTF8.GetString(DateTime_Buf, 13, 2);
                        temp_Minute = Encoding.UTF8.GetString(DateTime_Buf, 15, 2);
                        temp_Second = Encoding.UTF8.GetString(DateTime_Buf, 17, 2);
                        temp_DateTime = temp_Hour + ":" + temp_Minute + ":" + temp_Second;
                    }
                    if (lineNumber == 4)
                    {
                        LEQ5_Buf = Encoding.ASCII.GetBytes(line);
                        StrLEQ5 = Encoding.UTF8.GetString(LEQ5_Buf, 5, 5);
                        LEQ5 = Convert.ToDouble(StrLEQ5);
                    }
                    if (lineNumber == 5)
                    {
                        MAX_Buf = Encoding.ASCII.GetBytes(line);
                        StrMAX = Encoding.UTF8.GetString(MAX_Buf, 4, 5);
                        MAX = Convert.ToDouble(StrMAX);
                    }
                    if (lineNumber == 6)
                    {
                        MIN_Buf = Encoding.ASCII.GetBytes(line);
                        StrMIN = Encoding.UTF8.GetString(MIN_Buf, 4, 5);
                        MIN = Convert.ToDouble(StrMIN);
                        break;
                    }
                }
            }//using
            if (database != null && table != null)
            {
                if (dbConnect.CheckTableExist(database, table) == true)
                {
                    dbConnect.Insert(database, table, temp_DateTime, LEQ5, MAX, MIN);
                }
                else
                {
                    dbConnect.create_Tbactive(database, table);
                    if (dbConnect.CheckTableExist(database, table) == true)
                    {
                        dbConnect.Insert(database, table, temp_DateTime, LEQ5, MAX, MIN);
                    }
                }
            }
        }

        private void timerCheckClientStatus_Tick(object sender, EventArgs e)
        {
            dbConnect.CheckStatusOfClients("siteinfo","clieninfo");
        }

        public void AddDatabaseIntoListBox(string databaseName)
        {
            string databaseName_ = "noisedata_" + databaseName;
            lbxDatabase.Items.Add(databaseName_);
        }
        

       

       






    }
}
