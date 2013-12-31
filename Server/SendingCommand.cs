using System;
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
using System.Collections;
using System.Diagnostics;
using System.IO;
using ConnectCsharpToMysql;
namespace Server
{
    public partial class SendingCommand : UserControl
    {
        public SendingCommand()
        {
            InitializeComponent();
        }

        #region ListBox item change functions

        public void AddClient(IPEndPoint IpEndPoint)
        {
            lbxConnectedClients.BeginUpdate();
            string address = IpEndPoint.Address.ToString();
            string itemEndPoint;
            string[] tempAddress;
            string[] stringSeparators = new string[] {":"};
            foreach (object item in lbxConnectedClients.Items)
            {
                itemEndPoint = item.ToString();
                tempAddress = itemEndPoint.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string itemAddress = tempAddress[0];
                if (string.Equals(itemAddress, address, StringComparison.OrdinalIgnoreCase))
                {
                    lbxConnectedClients.Items.Remove(item);
                    break;
                }
                tempAddress = null;
            }
            string clientCode = null;
            //clientCode = GetClientClode(address);
            DBConnect dbConnect = new DBConnect();
            clientCode = dbConnect.GetSiteCodeFromIpAddress("siteinfo", "clieninfo", address);
            if (clientCode != null)
            {
                lbxConnectedClients.Items.Add(IpEndPoint.ToString() + ":" + clientCode);
            }
            else
            {
                lbxConnectedClients.Items.Add(IpEndPoint.ToString());
            }
            lbxConnectedClients.EndUpdate();
           
        }

        /// <summary>
        /// Remove the client address which disconnect from the server.
        /// </summary>
        /// <param name="ipAddress"></param>
        public void RemoveItem(string ipAddress)
        {
            int index = 0;
            bool flag = false;
            string[] temp_Str;
            string[] stringSeparators = new string[] { ":" };
            string temp_address;
            foreach (object item in lbxConnectedClients.SelectedItems)
            {
                temp_Str = item.ToString().Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                temp_address = temp_Str[0] + temp_Str[1];
                //if (!string.Equals(item.ToString(), ipAddress, StringComparison.OrdinalIgnoreCase))
                if(!string.Equals(temp_address,ipAddress,StringComparison.OrdinalIgnoreCase))
                {
                    index++;
                }
                else
                {
                    flag = true;
                    break;
                }
            }

            if (flag)
            {
                lbxConnectedClients.BeginUpdate();
                lbxConnectedClients.Items.RemoveAt(index);
                lbxConnectedClients.EndUpdate();
            }
        }
        #endregion

        #region Button Event
        /// <summary>
        /// Send Command to client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendingCommand_Click(object sender, EventArgs e)
        {
            if (lbxConnectedClients.SelectedItems.Count == 0)
            {
                //MessageBox.Show(this, Properties.Resources.SelectClientMsg);
                MessageBox.Show("Please select a client to send command");
                return;
            }
            if (cbbSelectionType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a type of command");
                return;
            }
            /*if (tbxClientCode.Text == null)
            {
                MessageBox.Show("Fill in the Client Code");
                return;
            }*/
            // before adding, we lbxConnectedClients should be zero
            string[] tempAddress;
            string[] stringSeparators = new string[] { ":" };
            string temp_Address;
            string clientCode = "0000000";
            foreach(object item in lbxConnectedClients.SelectedItems)
            {
                tempAddress = item.ToString().Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                temp_Address = tempAddress[0] + ":" + tempAddress[1];
                clientCode = tempAddress[2];
                foreach (Socket handler in AsynchronousSocketListener.Clients)
                {
                    IPEndPoint ipEndPoint = (IPEndPoint)handler.RemoteEndPoint;
                    string ipAddress = ipEndPoint.ToString();
                    if (string.Equals(temp_Address, ipAddress, StringComparison.OrdinalIgnoreCase))
                    {
                        try
                        {
                            AsynchronousSocketListener.ClientsToSend.Add(handler, ipEndPoint);
                        }
                        catch (ArgumentException)
                        {
                            

                        }
                        break;
                    }
                }//foreach2
            }//foreach1

           // btnSendingCommand.Enabled = false;

            if (cbbSelectionType.SelectedItem.ToString() == "Single File")
            {
                string fileType = null;
                string date = null;
                string tempDay = null;
                string tempMonth = null;
                string tempHour = null;
                string tempMinute = null;
                string tempSecond = null;
                string time = null;

                if (lbxFileTypeS.SelectedItem == null)
                {
                    MessageBox.Show("Select a file type");
                    return;
                }
                else
                {
                    fileType = lbxFileTypeS.SelectedItem.ToString();
                }
                
                if(dtpDateSingle.Value.Day < 10)
                {
                    tempDay = "0" + dtpDateSingle.Value.Day.ToString();
                }
                else
                {
                    tempDay = dtpDateSingle.Value.Day.ToString();
                }
                if(dtpDateSingle.Value.Month < 10)
                {
                    tempMonth = "0" + dtpDateSingle.Value.Month.ToString();
                }
                else
                {
                    tempMonth = dtpDateSingle.Value.Month.ToString();
                }
                date = dtpDateSingle.Value.Year.ToString() + tempMonth + tempDay;

                if (npuTimeSingleHour.Value < 10)
                {
                    tempHour = "0" + npuTimeSingleHour.Value.ToString();
                }
                else
                {
                    tempHour = npuTimeSingleHour.Value.ToString();
                }
                if (npuTimeSingleMinute.Value < 10)
                {
                    tempMinute = "0" + npuTimeSingleMinute.Value.ToString();
                }
                else
                {
                    tempMinute = npuTimeSingleMinute.Value.ToString();
                }
                if (npuTimeSingleSecond.Value < 10)
                {
                    tempSecond = "0" + npuTimeSingleSecond.Value.ToString();
                }
                else
                {
                    tempSecond = npuTimeSingleSecond.Value.ToString();
                }
                time = tempHour + tempMinute + tempSecond;
                string temp_DateTime = date + time;
                //btnSendingCommand.Enabled = false;
                Thread sendThread = new Thread(() => AsynchronousSocketListener.SendSingleFileCommand(fileType, temp_DateTime, clientCode));
                sendThread.Name = "Send Single File Command";
                sendThread.IsBackground = true;
                sendThread.Start();

            }
            else if (cbbSelectionType.SelectedItem.ToString() == "Time Period")
            {
                string fileType = null;
                //string date = null;
                string temp_FromDay = null;
                string temp_FromMonth = null;
                string temp_FromHour = null;
                string temp_FromMinute = null;
                string temp_fromSecond = null;
                string temp_ToDay = null;
                string temp_ToMonth = null;
                string temp_ToHour = null;
                string temp_ToMinute = null;
                string temp_ToSecond = null;
                string fromTime = null;
                string toTime = null;

                if (lbxFileTypeP.SelectedItem == null)
                {
                    MessageBox.Show("Select a file type");
                    return;
                }
                else
                {
                    fileType = lbxFileTypeP.SelectedItem.ToString();
                }
                if (dtpFromDate.Value.Day < 10)
                {
                    temp_FromDay = "0" + dtpFromDate.Value.Day.ToString();

                }
                else
                {
                    temp_FromDay = dtpFromDate.Value.Day.ToString();
                }
                if (dtpFromDate.Value.Month < 10)
                {
                    temp_FromMonth = "0" + dtpFromDate.Value.Month.ToString();
                }
                else
                {
                    temp_FromMonth = dtpFromDate.Value.Month.ToString();
                }
                if (npuFromTimeHour.Value < 10)
                {
                    temp_FromHour = "0" + npuFromTimeHour.Value.ToString();
                }
                else
                {
                    temp_FromHour = npuFromTimeHour.Value.ToString();
                }
                if (npuFromTimeMinute.Value < 10)
                {
                    temp_FromMinute = "0" + npuFromTimeMinute.Value.ToString();
                }
                else
                {
                    temp_FromMinute = npuFromTimeMinute.Value.ToString();
                }
                if (npuFromTimeSecond.Value < 10)
                {
                    temp_fromSecond = "0" + npuFromTimeSecond.Value.ToString();
                }
                else
                {
                    temp_fromSecond = npuFromTimeSecond.Value.ToString();
                }

                fromTime = dtpFromDate.Value.Year.ToString() + temp_FromMonth + temp_FromDay + temp_FromHour + temp_FromMinute + temp_fromSecond;

                if (dtpToDate.Value.Day < 10)
                {
                    temp_ToDay = "0" + dtpToDate.Value.Day.ToString();
                }
                else
                {
                    temp_ToDay = dtpToDate.Value.Day.ToString();
                }
                if (dtpToDate.Value.Month < 10)
                {
                    temp_ToMonth = "0" + dtpToDate.Value.Month.ToString();
                }
                else
                {
                    temp_ToMonth = dtpToDate.Value.Month.ToString();
                }
                if (npuToTimeHour.Value < 10)
                {
                    temp_ToHour = "0" + npuToTimeHour.Value.ToString();
                }
                else
                {
                    temp_ToHour = npuToTimeHour.Value.ToString();
                }
                if (npuToTimeMinute.Value < 10)
                {
                    temp_ToMinute = "0" + npuToTimeMinute.Value.ToString();
                }
                else
                {
                    temp_ToMinute = npuToTimeMinute.Value.ToString();
                }
                if (npuToTimeSecond.Value < 10)
                {
                    temp_ToSecond = "0" + npuToTimeSecond.Value.ToString();
                }
                else
                {
                    temp_ToSecond = npuToTimeSecond.Value.ToString();
                }

                toTime = dtpToDate.Value.Year.ToString() + temp_ToMonth + temp_ToDay + temp_ToHour + temp_ToMinute + temp_ToSecond;
                //btnSendingCommand.Enabled = false;
                Thread sendThread = new Thread(() => AsynchronousSocketListener.SendTimePeriodCommand(fileType, fromTime, toTime, clientCode));
                sendThread.IsBackground = true;
                sendThread.Name = "Send Time Period Command";
                sendThread.Start();
            }
            

        }//sendingcommand

        public void btnSendingCommand_Enable()
        {
            btnSendingCommand.Enabled = true;
        }

        #endregion

        #region Additional function

        private string GetClientClode(string ipAddress)
        {
            string clientCode = null;
            byte[] temp_buf;
            string[] temp_Str;
            string[] stringSeparators = new string[] { ":" };
            string temp_ipAddr;
            using (StreamReader reader = new StreamReader("ClientCode.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    temp_buf = Encoding.ASCII.GetBytes(line);
                    temp_Str = line.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                    temp_ipAddr = temp_Str[0];
                    if (string.Equals(temp_ipAddr, ipAddress, StringComparison.OrdinalIgnoreCase))
                    {
                        return temp_Str[2];
                    }
                }
            }
            return clientCode;
        }

        #endregion






    }//class
}//namespace
