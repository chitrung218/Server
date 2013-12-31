using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
//Add MySql Library
using MySql.Data.MySqlClient;
using Server;
namespace ConnectCsharpToMysql
{
    class DBConnect
    {
        private static MySqlConnection connection;
        private static string server;
        private static string database;
        private static string uid;
        private static string password;
        public static string MysqlDumpPath;
        public static string MysqlPath = null;
        public static string MysqlDatabaseFileRestore = null;
        //Constructor
        public DBConnect()
        {
            //Initialize();
        }

        public void setServer(string serverName)
        {
            server = serverName;
        }
        public void setDatabase(string databaseName)
        {
            database = databaseName;
        }
        public void setUsername(string Username)
        {
            uid = Username;
        }
        public void setPassword(string pass)
        {
            password = pass;
        }
        public MySqlConnection getConnection()
        {
            return connection;
        }
        //Initialize values
        public void Initialize()
        {
            //server = "localhost";
            //database = "mydb";
            //uid = "root";
            //password = "mysql";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }


        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                //MessageBox.Show("Connect to sever");
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
        public bool OpenConnection(MySqlConnection tempConn)
        {
            try
            {
                tempConn.Open();
                //MessageBox.Show("Connect to sever");
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private bool CloseConnection(MySqlConnection tempConn)
        {
            try
            {
                tempConn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        //Insert statement
        public void Insert()
        {
            string name = "John";
            string value = "VALUE" + "(" + "'4'" + "," + "'" + name +"'" +"," + "'West'" +")";
            //string query = "INSERT INTO extable1 (idExTable1, Name, Address) VALUES('3',, 'West')";
            string query = "INSERT INTO extable1 (idExTable1, Name, Address)" + value;
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);
                
                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public void Insert(string databaseName_, string table_, string datetime_, double LEQ5_, double MAX_, double MIN_)
        {
            //string name = "John";
            //string value = "VALUE" + "(" + "'4'" + "," + "'" + name + "'" + "," + "'West'" + ")";
            //string query = "INSERT INTO extable1 (idExTable1, Name, Address) VALUES('3',, 'West')";
            //string query = "INSERT INTO extable1 (idExTable1, Name, Address)" + value;
            string value = "VALUE" + "(" + "'" + datetime_ + "'" + "," + "'" + LEQ5_ + "'" + "," + "'" + MAX_ + "'" + "," + "'" + MIN_ + "'" + ")";
            string query = "INSERT INTO " + table_ + " (DateTime, LEQ5, MAX, MIN)" + value;
            string tempString = "SERVER=" + server + ";" + "DATABASE=" + databaseName_ + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            //open connection
            using (MySqlConnection conn = new MySqlConnection(tempString))
            {
                if (OpenConnection(conn) == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection(conn);
                }
            }
        }

        //Update statement
        public void Update()
        {
            string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete()
        {
            string query = "DELETE FROM tableinfo WHERE name='John Smith'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Select statement
        public List<string>[] Select(string queryTable)
        {
            //bool tableExist = CheckTableExist(this.database, queryTable);
            List<string>[] list = new List<string>[4];
            /*if (tableExist == false)
            {
                return list;
            }*/
            string query = "SELECT * FROM " + queryTable;

            //Create a list to store the result
          
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["DateTime"] + "");
                    list[1].Add(dataReader["LEQ5"] + "");
                    list[2].Add(dataReader["MAX"] + "");
                    list[3].Add(dataReader["MIN"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM tableinfo";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar()+"");
                
                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        //Backup
        public void Backup(string databaseName_)
        {
            try
            {
                DateTime Time = DateTime.Now;
                int year = Time.Year;
                int month = Time.Month;
                int day = Time.Day;
                int hour = Time.Hour;
                int minute = Time.Minute;
                int second = Time.Second;
                int millisecond = Time.Millisecond;

                //Save file to C:\ with the current date as a filename
                string path;
                path = ServerForm.DatabaseDumpFolder + "\\" + year + "-" + month + "-" + day + "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
                StreamWriter file = new StreamWriter(path);

                
                ProcessStartInfo psi = new ProcessStartInfo();
                //psi.FileName = "mysqldump";
                psi.FileName = MysqlDumpPath;
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", uid, password, server, databaseName_);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);

                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error , unable to backup!");
            }
        }

        //Restore
        public void Restore(string databaseName_)
        {
            try
            {
                //Read file from C:\
                if (MysqlDatabaseFileRestore == null)
                {
                    MessageBox.Show("Please choose database file need to be restored");
                    return;
                }
                string path;
                //path = "C:\\MySqlBackup.sql";
                path = MysqlDatabaseFileRestore;
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();


                ProcessStartInfo psi = new ProcessStartInfo();
                //psi.FileName = "mysql";
                psi.FileName = MysqlPath;
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", uid, password, server, databaseName_);
                psi.UseShellExecute = false;

                
                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error , unable to Restore!");
            }
        }

        // Create table dynamically
        public void create_Tbactive(string database_name, string table_name)
        {
            
                // Create a MySQL table in the selected database

                //string st = ("CREATE TABLE" + " testTable" + " (id INT NOT NULL AUTO_INCREMENT,PRIMARY KEY(id),naam VARCHAR(30),Url VARCHAR(30))");
                string st = ("CREATE TABLE " + table_name + " (Time TIME NOT NULL,PRIMARY KEY(Time),LEQ5 DOUBLE,MAX DOUBLE, MIN DOUBLE)");
                string tempString = "SERVER=" + server + ";" + "DATABASE=" + database_name + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                using (MySqlConnection conn = new MySqlConnection(tempString))
                {
                    if (OpenConnection(conn) == true)
                    {
                        MySqlCommand MySqlCommand = new MySqlCommand(st, conn);

                        MySqlCommand.ExecuteNonQuery();
                        this.CloseConnection(conn);
                    }

                }        
        }

        ///Check the table exist or not
        ///
        public bool CheckTableExist(string database_name, string table_name)
        {
            //string cmdStr = ("SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = 'noisedata_2826501' AND table_name = 'testtable2'");
            string cmdStr = ("SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = " + "'" + database_name + "'" + " AND table_name = " + "'" + table_name +"'");
            string tempString = "SERVER=" + server + ";" + "DATABASE=" + database_name + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            using (MySqlConnection conn = new MySqlConnection(tempString))
            {
                if (OpenConnection(conn) == true)
                {
                    MySqlCommand cmd = new MySqlCommand(cmdStr, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int count = reader.GetInt32(0);
                        if (count == 0)
                        {
                            //MessageBox.Show("No such data table exists!");
                            return false;
                        }
                        else
                        {
                            //MessageBox.Show("Such data table exists!");
                            return true;
                        }
                    }
                    return false;

                }
                else
                    return false;
            }
        }


        // Check whether a database exist or not

        public bool CheckDatabaseExist(string database_name)
        {
           
            string connectionLine;

            // Crete a connection string
            
            connectionLine = "SERVER=" + server + ";" + "DATABASE=" + database_name + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            using (MySqlConnection connect = new MySqlConnection(connectionLine))
            {
                try
                {

                    connect.Open();

                }
                catch
                {
                    //MessageBox.Show("Error" + ex.ToString());

                    return false;
                }
                connect.Close();
                return true;
            }
        }

       
        //Create Database programmatically

        public void CreateDatabaseActive(string database_name)
        {
            // check whether the database exist???
            if (CheckDatabaseExist(database_name))
            {
                return;
            }
            string connectionLine;
            string commandLine;
            commandLine = "CREATE DATABASE " + database_name + ";";
            // Crete a connection string
            connectionLine = "SERVER=" + server + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            using (MySqlConnection connect = new MySqlConnection(connectionLine))
            {
                if (OpenConnection(connect) == true)
                {
                    MySqlCommand MySqlCommand = new MySqlCommand(commandLine, connect);

                    MySqlCommand.ExecuteNonQuery();
                    this.CloseConnection(connect);
                }
            }
            
        }

        //Insert a client into siteinfo database

        public void InsertClientInfo(string databaseName_, string table_, string code_, string siteNum_, string siteCode_, int connect_ , string IpAddr_)
        {
            string time = null;
            DateTime dateTime = DateTime.Now;
            time = dateTime.Year.ToString() + "-" + dateTime.Month.ToString() + "-" + dateTime.Day.ToString() + " 00-00-00";
            string value = "VALUE" + "(" + "'" + code_ + "'" + "," + "'" + siteNum_ + "'" + "," + "'" + siteCode_ + "'" + "," + "'" + IpAddr_ + "'" + "," + "'" + connect_ + "'" + "," + "'" + time + "'" + ")";
            string query = "INSERT INTO " + table_ + " (CODE, SITE_NM, SITE_CODE, IP_ADDRESS, CONNECT,TIME)" + value;
            string tempString = "SERVER=" + server + ";" + "DATABASE=" + databaseName_ + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            //open connection
            using (MySqlConnection conn = new MySqlConnection(tempString))
            {
                if (OpenConnection(conn) == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection(conn);
                }
            }
        }

        //Delete a client from siteinfo database

        public void DeleteClient(string databaseName_, string table_, string code_)
        {
            string query = "DELETE FROM " + table_ + " WHERE CODE=" + code_;
            string tempString = "SERVER=" + server + ";" + "DATABASE=" + databaseName_ + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            //open connection
            using (MySqlConnection conn = new MySqlConnection(tempString))
            {
                if (OpenConnection(conn) == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection(conn);
                }
            }
        }

        //Update Connecting Time into siteinfo database

        public void UpdateConnectingTime(string databaseName_, string table_,string sitecode_,string datetime_)
        {
            //string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

            string query = "UPDATE " + table_ + " SET TIME=" + "'" + datetime_ + "'" + " WHERE SITE_CODE=" + "'" + sitecode_ + "'";

            string tempString = "SERVER=" + server + ";" + "DATABASE=" + databaseName_ + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            //open connection
            using (MySqlConnection conn = new MySqlConnection(tempString))
            {
                if (OpenConnection(conn) == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection(conn);
                }
            }
        }

        //Update Status Connect of Client

        public void UpdateConnectStatus(string databaseName_, string table_, string sitecode_, int status)
        {
            string query = "UPDATE " + table_ + " SET CONNECT=" + "'" + status.ToString() + "'" + " WHERE SITE_CODE=" + "'" + sitecode_ + "'";

            string tempString = "SERVER=" + server + ";" + "DATABASE=" + databaseName_ + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            //open connection
            using (MySqlConnection conn = new MySqlConnection(tempString))
            {
                if (OpenConnection(conn) == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection(conn);
                }
            }
        }

        //Select a client based on site_code

        public void SelectClientFromSiteCode(string databaseName_, string table_, string sitecode_)
        {
            string query = "SELECT * FROM " + table_ + " WHERE SITE_CODE=" + "'" + sitecode_ + "'" ;
            string tempString = "SERVER=" + server + ";" + "DATABASE=" + databaseName_ + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            string connectingTime = null;
            //open connection
            using (MySqlConnection conn = new MySqlConnection(tempString))
            {
                if (OpenConnection(conn) == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        connectingTime = dataReader["TIME"].ToString();
                    }
                    dataReader.Close();
                    //close connection
                    this.CloseConnection(conn);
                }
            }
        }

        // Check the expiration of connecting time of clients

        public void CheckStatusOfClients(string databaseName_, string table_)
        {
            string tempString = "SERVER=" + server + ";" + "DATABASE=" + databaseName_ + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            string query = "SELECT * FROM " + table_;
            string connectingTime = null;
            using (MySqlConnection conn = new MySqlConnection(tempString))
            {
                if (OpenConnection(conn) == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    DateTime dt1 = DateTime.Now;
                    while (dataReader.Read())
                    {
                        connectingTime = dataReader["TIME"].ToString();
                        if (connectingTime == null)
                        {
                            this.UpdateConnectStatus("siteinfo", "clieninfo", dataReader["SITE_CODE"].ToString(), 0);
                            continue;
                        }
                        DateTime dt2 = Convert.ToDateTime(connectingTime);
                        if (dt2.AddSeconds(13.0) < dt1)
                        {
                            this.UpdateConnectStatus("siteinfo", "clieninfo", dataReader["SITE_CODE"].ToString(), 0);
                        }
                        else
                        {
                            this.UpdateConnectStatus("siteinfo", "clieninfo", dataReader["SITE_CODE"].ToString(), 1);
                        }
                    }
                    dataReader.Close();
                    //close connection
                    this.CloseConnection(conn);
                }
            }
        }

        //Get Sitecode from ipaddress

        public string GetSiteCodeFromIpAddress(string databaseName_, string table_, string ipAddress)
        {
            string tempString = "SERVER=" + server + ";" + "DATABASE=" + databaseName_ + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            string query = "SELECT * FROM " + table_;
            string tempAddr = null;
            string sitecode = null;
            using (MySqlConnection conn = new MySqlConnection(tempString))
            {
                if (OpenConnection(conn) == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        tempAddr = dataReader["IP_ADDRESS"].ToString();
                        if (String.Equals(tempAddr, ipAddress, StringComparison.OrdinalIgnoreCase))
                        {
                            sitecode = dataReader["SITE_CODE"].ToString();
                        }
                    }

                    dataReader.Close();
                    CloseConnection(conn);
                }
                
            }
            return sitecode;
        }

        public List<string> GetAllSiteCode(string databaseName_,string queryTable)
        {
            //bool tableExist = CheckTableExist(this.database, queryTable);
            List<string> list = new List<string>();
            /*if (tableExist == false)
            {
                return list;
            }*/
            string query = "SELECT * FROM " + queryTable;
            string tempString = "SERVER=" + server + ";" + "DATABASE=" + databaseName_ + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            
            //Open connection
            using (MySqlConnection conn = new MySqlConnection(tempString))
            {
                if (OpenConnection(conn) == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        list.Add(dataReader["SITE_CODE"].ToString());
                    }
                    //close Data Reader
                    dataReader.Close();
                    //close connection
                    this.CloseConnection(conn);
                    //return list to be displayed
                    return list;
                }
                else
                {
                    return list;
                }
            }
            
        }
        
    }
}
