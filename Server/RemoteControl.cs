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
    public partial class RemoteControl : UserControl
    {
        public RemoteControl()
        {
            InitializeComponent();
           
        }

        private void ovalShape1_Click(object sender, EventArgs e)
        {

        }
        public void AddClientToRemoteControl(IPEndPoint IpEndPoint)
        {
            lbxConnectedClients.BeginUpdate();
            string address = IpEndPoint.Address.ToString();
            string itemEndPoint;
            string[] tempAddress;
            string[] stringSeparators = new string[] { ":" };
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
        /// Sending SETT Command to clients
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendSETT_Click(object sender, EventArgs e)
        {
            /*if (lbxConnectedClients.SelectedItems.Count == 0)
            {
                //MessageBox.Show(this, Properties.Resources.SelectClientMsg);
                MessageBox.Show("Please select a client to send command");
                return;
            }*/
            //btnSendSETT.Enabled = false;

            string[] tempAddress;
            string[] stringSeparators = new string[] { ":" };
            string temp_Address;
            string clientCode = "0000000";
            foreach (object item in lbxConnectedClients.SelectedItems)
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
                        AsynchronousSocketListener.ClientsToSend.Add(handler, ipEndPoint);
                        break;
                    }
                }//foreach2
            }//foreach1
            string date = null;
            string tempDay = null;
            string tempMonth = null;
            string tempHour = null;
            string tempMinute = null;
            string tempSecond = null;
            string time = null;
            if (dtpDate.Value.Day < 10)
            {
                tempDay = "0" + dtpDate.Value.Day.ToString();
            }
            else
            {
                tempDay = dtpDate.Value.Day.ToString();
            }
            if (dtpDate.Value.Month < 10)
            {
                tempMonth = "0" + dtpDate.Value.Month.ToString();
            }
            else
            {
                tempMonth = dtpDate.Value.Month.ToString();
            }
            date = dtpDate.Value.Year.ToString() + tempMonth + tempDay;

            if (nUDHour.Value < 10)
            {
                tempHour = "0" + nUDHour.Value.ToString();
            }
            else
            {
                tempHour = nUDHour.Value.ToString();
            }
            if (nUDMinute.Value < 10)
            {
                tempMinute = "0" + nUDMinute.Value.ToString();
            }
            else
            {
                tempMinute = nUDMinute.Value.ToString();
            }
            if (nUDSecond.Value < 10)
            {
                tempSecond = "0" + nUDSecond.Value.ToString();
            }
            else
            {
                tempSecond = nUDSecond.Value.ToString();
            }
            time = tempHour + tempMinute + tempSecond;
            string temp_DateTime = date + time;
            Thread sendThread = new Thread(() => AsynchronousSocketListener.SendSETTCommand(temp_DateTime, clientCode));
            sendThread.IsBackground = true;
            sendThread.Name = "Send SETT Command";
            sendThread.Start();
        }

        /// <summary>
        ///  Remove items from Connected Clients Listbox
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
                if (!string.Equals(temp_address, ipAddress, StringComparison.OrdinalIgnoreCase))
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
    }
}
