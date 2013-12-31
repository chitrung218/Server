using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using ReflectSoftware.Insight;
using System.ComponentModel;
using ConnectCsharpToMysql;

namespace Server
{
    
    public class StateObject
    {
        public Socket workSocket = null;
        public const int BufferSize = 1024 * 1000;
        public byte[] buffer = new byte[BufferSize];
        public int flag = 0;
        public string receivedPath = null;
        public int receivedRetry = 0;
    }

    public class Part : IEquatable<Part>
    {
        public string PartIpAddress { get; set; }

        public string PartClientCode { get; set; }

        public DateTime PartTime { get; set; }

        /*public override string ToString()
        {
            return "ID: " + PartId + "   Name: " + PartName;
        }*/
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Part objAsPart = obj as Part;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        /*public override string GetHashCode()
        {
            return PartClientCode;
        }*/
        public string GetClientCode()
        {
            return PartClientCode;
        }
        public bool Equals(Part other)
        {
            if (other == null) return false;
            return (this.PartClientCode.Equals(other.PartClientCode));
        }
        // Should also override == and != operators.

    }
    /// <summary>
    /// AsynchronousSocketListener is used to asynchronously listen the client and send file to the client.
    /// </summary>
    public static class AsynchronousSocketListener
    {
        #region Constants
        private const int c_clientSockets = 100;
        #endregion

        #region Members

        private static int flag = 0;
        private static string receivedPath;
        public static string saveFolder; // this is a folder to save received data from clients
        public static bool trace = true;
        public static string curMsg = "Stopped";
        private static int dataPort;
        private static int statusPort;
        //private static int signal;
        public static bool suspend = false;
        private static int receiveRetry = 0;
        private static UInt32 totalByteReceived = 0;
        private static int tempByteReceived = 0;
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        private static ManualResetEvent receiveStatusDone = new ManualResetEvent(false);
        private static ManualResetEvent sendDone = new ManualResetEvent(false);
        private static ManualResetEvent sendCommandDone = new ManualResetEvent(false);
        private static ManualResetEvent allSendCommandDone = new ManualResetEvent(false);
        private static Mutex mut = new Mutex();
        private delegate void AddClientHandler(IPEndPoint IpEndPoint);
        private delegate void EnableButtonStop();
        private delegate void EnableButtonStartup();
        private delegate void EnableButtonSendingCommmand();
        private delegate void CompleteSendHandler();
        private delegate void RemoveItemHandler(string ipAddress);
        private delegate void EnableSendHandler();

        #endregion

        #region Properties

        public static IList<Socket> Clients = new List<Socket>();
        public static IDictionary<Socket, IPEndPoint> ClientsToSend = new Dictionary<Socket, IPEndPoint>();
        
        public static List<Part> partClients = new List<Part>(); // this list is used to check the status of clients
        public static ServerSetup Server { get; set; }

        public static SendingCommand serverSendCommand { get; set; } // is set at ServerForm Designer
        public static RemoteControl remoteControlCommand { get; set; }
        public static string DataPort
        {
            set
            {
                try
                {
                    dataPort = Convert.ToInt32(value);
                }
                catch (FormatException)
                {
                    throw new Exception(Properties.Resources.InvalidPortMsg);
                }
                catch (OverflowException ex)
                {
                    throw new Exception(ex.Message);
                }

                if (dataPort < 0 || dataPort > 65535)
                {
                    throw new Exception(Properties.Resources.InvalidPortMsg);
                }
            }
        }

        public static string StatusPort
        {
            set
            {
                try
                {
                    statusPort = Convert.ToInt32(value);
                }
                catch (FormatException)
                {
                    throw new Exception(Properties.Resources.InvalidPortMsg);
                }
                catch (OverflowException ex)
                {
                    throw new Exception(ex.Message);
                }

                if (statusPort < 0 || statusPort > 65535)
                {
                    throw new Exception(Properties.Resources.InvalidPortMsg);
                }
            }
        }

        #endregion

        #region Functions

        /// <summary>
        /// Server start to listen the client connection.
        /// </summary>

        public static void StartListening(BackgroundWorker bgWorker, DoWorkEventArgs e)
        {
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, dataPort);

            // Use IPv4 as the network protocol,if you want to support IPV6 protocol, you can update here.
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            try
            {
                listener.Bind(localEndPoint);
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            listener.Listen(c_clientSockets);

            curMsg = "Start...";
            
            //loop listening the client.
            while (true)
            {
                
                //Server.BeginInvoke(new EnableButtonStop(Server.btnStop_Enable));

                while (AsynchronousSocketListener.suspend)
                {
                    allDone.WaitOne();
                }

                allDone.Reset();
                curMsg = "Waiting for connection...";
                
                Trace.WriteLine("Waiting for connection...");
                listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                
                
                ///
                allDone.WaitOne();
            }
        }

        ///<summary>
        ///Server starts listening status port
        ///</summary>

        public static void StartListening1()
        {
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, statusPort);

            // Use IPv4 as the network protocol,if you want to support IPV6 protocol, you can update here.
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            try
            {
                listener.Bind(localEndPoint);
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            listener.Listen(c_clientSockets);

            //curMsg = "Start...";

            //loop listening the client.
            while (true)
            {
                receiveStatusDone.Reset();
                //urMsg = "Waiting for connection...";
                listener.BeginAccept(new AsyncCallback(AcceptStatusCallBack), listener);
                receiveStatusDone.WaitOne();
            }
        }

        ///<summary>
        ///Call back when client succesfully connected to the server through status port
        ///</summary>

        private static void AcceptStatusCallBack(IAsyncResult ar)
        {
            
            receiveStatusDone.Set();

            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            IPEndPoint ipEndPoint = handler.RemoteEndPoint as IPEndPoint;
           
            // Receive data from status port
            

            if ((ipEndPoint) != null)
            {
                // AddClientHandler clientHandler = Server.AddClient;

                //Server.BeginInvoke(new AddClientHandler(Server.AddClient), ipEndPoint);
                // Server.BeginInvoke(clientHandler, ipEndPoint);
                serverSendCommand.BeginInvoke(new AddClientHandler(serverSendCommand.AddClient), ipEndPoint);
                remoteControlCommand.BeginInvoke(new AddClientHandler(remoteControlCommand.AddClientToRemoteControl), ipEndPoint);
            }
            /*foreach (object item Clients.Item)
            {
                IPEndPoint temp_ipEndPoint = (IPEndPoint)temp_handler.RemoteEndPoint;
                string address = ipEndPoint.Address.ToString();
                string[] tempAddress;
                string[] stringSeparators = new string[] { ":" };
                if (string.Equals(item.ToString(), ipAddress, StringComparison.OrdinalIgnoreCase))
                {
                    AsynchronousSocketListener.ClientsToSend.Add(handler, ipEndPoint);
                    break;
                }
            }*/
            mut.WaitOne();
            /*if (Clients.Count == 0)
            {
                Clients.Add(handler);

            }*/
            
            for (int i = 0; i < Clients.Count; i++)
            {
                IPEndPoint temp_ipEndPoint = (IPEndPoint)Clients.ElementAt(i).RemoteEndPoint;
                string itemipEndPoint = temp_ipEndPoint.ToString();
                string address = ipEndPoint.Address.ToString();
                string[] tempAddress;
                string[] stringSeparators = new string[] { ":" };
                tempAddress = itemipEndPoint.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string itemAddress = tempAddress[0];
                if (string.Equals(itemAddress, address, StringComparison.OrdinalIgnoreCase))
                {
                    Clients.RemoveAt(i);
                    //Clients.Add(handler);
                    break;
                }

            }
            Clients.Add(handler);

            mut.ReleaseMutex();

            //Clients.Add(handler);
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback2), state);
            

        }
        /// <summary>
        /// This function is used to process when data is received from clients from status port
        /// </summary>
        /// <param name="ar"></param>
        private static void ReadCallback2(IAsyncResult ar)
        {
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;
            IPEndPoint ipEndPoint = handler.RemoteEndPoint as IPEndPoint;
            string temp_Addr = ipEndPoint.Address.ToString();
            int bytesRead = 0;
            string clientCode = null;
            try
            {
                bytesRead = handler.EndReceive(ar);
            }
            catch (SocketException e)
            {
                if (trace)
                {
                    Trace.WriteLine("An error occuring due to error " + e.Message);
                }
                //receiveStatusDone.Set();
                handler.Shutdown(SocketShutdown.Both);
                handler.Disconnect(true);
                handler.Close();
                handler.Dispose();
                return;
            }
            if (bytesRead > 0)
            {
                clientCode = Encoding.UTF8.GetString(state.buffer, 10, 7);
                if (clientCode != null)
                {
                    DateTime dt = DateTime.Now;
                    string curTime = dt.ToString("yyyy/MM/dd HH:mm:ss");
                    DBConnect dbConnect = new DBConnect();
                    Thread t = new Thread(() => dbConnect.UpdateConnectingTime("siteinfo", "clieninfo", clientCode, curTime));
                    //dbConnect.UpdateConnectingTime("siteinfo", "clieninfo", clientCode ,curTime);
                    t.Start();
                    //receiveStatusDone.Set();
                    return;
                }

            }
            else
            {
                if (state.receivedRetry != 5)
                {
                    state.receivedRetry++;
                    try
                    {
                        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReadCallback2), state);
                    }
                    catch (SocketException e)
                    {
                        if (!handler.Connected)
                        {
                            //MessageBox.Show(Properties.Resources.DisconnectMsg);
                            if (trace)
                            {
                                Trace.WriteLine("Disconnect from client due to error " + e.Message);
                            }

                            handler.Shutdown(SocketShutdown.Both);
                            handler.Disconnect(true);
                            handler.Close();
                            handler.Dispose();
                            return;
                        }
                    }

                }
                else
                {
                    if (trace)
                    {
                        Trace.WriteLine("Fail to received " + " from " + ipEndPoint.ToString());
                    }
                    
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Disconnect(true);
                    handler.Close();
                    handler.Dispose();
                    return;
                }
            }
            
        }

        /// <summary>
        /// Callback when one client successfully connected to the server.
        /// </summary>
        /// <param name="ar"></param>
        private static void AcceptCallback(IAsyncResult ar)
        {
            ///Disable Button at ServerSetup
            //Server.BeginInvoke(new EnableButtonStop(Server.btnStop_Disable));

            ///
            allDone.Set();
            ///
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            IPEndPoint ipEndPoint = handler.RemoteEndPoint as IPEndPoint;
            
            // Trace

            if (trace)
            {
                Trace.WriteLine(" Accept Connection from " + ipEndPoint.ToString());
            }


            if ((ipEndPoint) != null)
            {
              // AddClientHandler clientHandler = Server.AddClient;

                Server.BeginInvoke(new AddClientHandler(Server.AddClient),ipEndPoint);
               // Server.BeginInvoke(clientHandler, ipEndPoint);
            }

            //Clients.Add(handler);

            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback1), state);
            
        }

        /// <summary>
        /// Original code
        /// </summary>
        /// <param name="ar"></param>
        public static void ReadCallback(IAsyncResult ar)
        {
            curMsg = "Receving Data...";
            int fileNameLen = 1;
            String content = String.Empty;
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;
            int bytesRead = handler.EndReceive(ar);
            if (bytesRead > 0)
            {

                if (flag == 0)
                {
                    fileNameLen = BitConverter.ToInt32(state.buffer, 0);
                    string fileName = Encoding.UTF8.GetString(state.buffer, 4, fileNameLen);
                    /*string path = @"C:\Users\Chi Trung\Desktop\test\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }*/
                    //receivedPath = @"C:\Users\Chi Trung\Desktop\test\" + fileName;
                    receivedPath = saveFolder + fileName;
                    flag++;
                }
                if (flag >= 1)
                {
                    BinaryWriter writer = new BinaryWriter(File.Open(receivedPath, FileMode.Append));
                    if (flag == 1)
                    {
                        curMsg = "Saving Data...";
                        writer.Write(state.buffer, 4 + fileNameLen, bytesRead - (4 + fileNameLen));
                        writer.Close();
                        flag++;
                        try
                        {
                            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                            new AsyncCallback(ReadCallback), state);
                        }
                        catch
                        {
                            if (!handler.Connected)
                            {
                                MessageBox.Show(Properties.Resources.DisconnectMsg);
                            }
                        }
                    }// flag = 1
                    else
                    {
                        curMsg = "Saving Data...";
                        writer.Write(state.buffer, 0, bytesRead);
                        writer.Close();
                        try
                        {
                            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                            new AsyncCallback(ReadCallback), state);
                        }
                        catch
                        {
                            if (!handler.Connected)
                            {
                                MessageBox.Show(Properties.Resources.DisconnectMsg);
                            }
                        }
                    }//else
                }//flag >= 1

            }
            else
            {
                //
                flag = 0;
                handler.Shutdown(SocketShutdown.Send);
                handler.Disconnect(true);
                handler.Close();
                handler.Dispose();
                allDone.Set();
                //AsynchronousSocketListener.StartListening();
                
            }
        }//ReadCallback

        /// <summary>
        /// This function is used to process when data is received from clients
        /// </summary>
        /// <param name="ar"></param>
        public static void ReadCallback1(IAsyncResult ar)
        {
            curMsg = "Receving Data...";
            //int fileNameLen = 1;
            String content = String.Empty;
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;
            IPEndPoint ipEndPoint = handler.RemoteEndPoint as IPEndPoint;
            int number ;
            UInt16 command_block_size ;
            UInt16 data_block_size ;
            string reportID ;
            string clientCode ;
            string filename ;
            UInt32 totalByte;
            UInt32 startPoint ;
            UInt16 sendingByte ;
            int bytesRead = 0;
            char[] tempDate = new char[8];
            try
            {
                bytesRead = handler.EndReceive(ar);
            }
            catch (SocketException e)
            {
                if (trace)
                {
                    Trace.WriteLine("An error occuring due to error " + e.Message);
                }
                /*flag = 0;
                receiveRetry = 0;
                totalByteReceived = 0;
                tempByteReceived = 0;*/

                //allDone.Set();
                //AsynchronousSocketListener.StartListening();
                handler.Shutdown(SocketShutdown.Both);
                handler.Disconnect(true);
                handler.Close();
                handler.Dispose();
                //allDone.Set();
                
                return;
            }
            
            if (bytesRead > 0)
            {
                byte STX = state.buffer[0];
                number = BitConverter.ToInt32(state.buffer, 1);
                command_block_size = BitConverter.ToUInt16(state.buffer, 5);
                data_block_size = BitConverter.ToUInt16(state.buffer, 7);
                reportID = Encoding.UTF8.GetString(state.buffer, 9, 4);
                clientCode = Encoding.UTF8.GetString(state.buffer, 13, 7);
                filename = Encoding.UTF8.GetString(state.buffer, 20, 18);
                totalByte = BitConverter.ToUInt32(state.buffer, 38);
                //totalByteReceived = totalByte;
                startPoint = BitConverter.ToUInt32(state.buffer, 42);
                sendingByte = BitConverter.ToUInt16(state.buffer, 46);
                //tempByteReceived += sendingByte;
                if (STX == 0x04)
                {
                    //Finish receiving data file
                    if (trace)
                    {
                        Trace.WriteLine("Finish receiving " + filename + "from " + clientCode + " at " + ipEndPoint.ToString());
                    }

                    /*flag = 0;
                    receiveRetry = 0;
                    totalByteReceived = 0;
                    tempByteReceived = 0;*/

                   // Thread t = new Thread(() => ConnectDatabase.RecordDataIntoDatabase(receivedPath));
                    //t.Start();
                    //allDone.Set();
                    //AsynchronousSocketListener.StartListening();
                    //allDone.Set();
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Disconnect(true);
                    handler.Close();
                    handler.Dispose();


                    return;

                }
                //Trace

                if (trace)
                {
                    Trace.WriteLine("Receiving " + filename + " from " + clientCode + " at " + ipEndPoint.ToString() );
                }

                //if (flag == 0)// use flag as static memeber of class AsynchronousSocketListener
                if(state.flag == 0)
                {

                    //string clientAddress = ipEndPoint.Address.ToString();

                    filename.CopyTo(0, tempDate, 0, 8);
                    string date = null;
                    date = new string(tempDate);

                    string path = null;
                    if (string.Compare(reportID, "DM05", false) == 0 || string.Compare(reportID, "RM05", false) == 0)
                    {
                        path = saveFolder + "\\NoiseData\\" + clientCode + "\\" + date;
                    }
                    else if (string.Compare(reportID, "DMOT", false) == 0 || string.Compare(reportID, "RMOT", false) == 0)
                    {
                        path = saveFolder + "\\RecordOctave\\" + clientCode + "\\" + date;
                    }
                    else if (string.Compare(reportID, "DMP3", false) == 0 || string.Compare(reportID, "RMP3", false) == 0)
                    {
                        path = saveFolder + "\\RecordMP3\\" + clientCode + "\\" + date;
                    }
                    else if (string.Compare(reportID, "DMWC", false) == 0 || string.Compare(reportID, "DMPW", false) == 0)
                    {
                        path = saveFolder + "\\RecordWECPNL\\" + clientCode + "\\" + date;
                    }
                    else if (string.Compare(reportID, "DLST", false) == 0 || string.Compare(reportID, "RLST", false) == 0)
                    {
                        path = saveFolder + "\\RecordList\\" + clientCode + "\\" +  date;
                    }
                    else if (string.Compare(reportID, "RCHK", false) == 0)
                    {
                        path = saveFolder + "\\CmdResult\\" + clientCode + "\\" + date;
                    }
                    else
                    {
                        if (trace)
                        {
                            Trace.WriteLine("Receive an unknown filename");
                        }
                        handler.Shutdown(SocketShutdown.Both);
                        handler.Disconnect(true);
                        handler.Close();
                        handler.Dispose();
                        return;

                    }
                    //receivedPath = @"C:\Users\Chi Trung\Desktop\test\" + filename;
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    //receivedPath = path + "\\" + filename;
                    state.receivedPath = path + "\\" + filename;
                    //flag++;
                    state.flag++;
                    
                }
                //if (flag >= 1)
                if(state.flag >= 1)
                {

                    //using ( BinaryWriter writer = new BinaryWriter(File.Open(receivedPath, FileMode.Append)))
                    using (BinaryWriter writer = new BinaryWriter(File.Open(state.receivedPath, FileMode.Append)))
                    {
                        //if (flag == 1)
                        if(state.flag == 1)
                        {
                            curMsg = "Saving Data...";
                            writer.Write(state.buffer, 48,sendingByte);
                            writer.Close();
                            //
                            //send ACK
                            sendDone.Reset();
                            SendAcknowledge(state);
                            sendDone.WaitOne();

                            //flag++;
                            state.flag++;
                            try
                            {
                                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                new AsyncCallback(ReadCallback1), state);
                            }
                            catch (SocketException e)
                            {
                                if (!handler.Connected)
                                {

                                    //MessageBox.Show(Properties.Resources.DisconnectMsg);
                                    if (trace)
                                    {
                                        Trace.WriteLine("Disconnect from client due to error " + e.Message);
                                    }
                                    /*flag = 0;
                                    receiveRetry = 0;
                                    totalByteReceived = 0;
                                    tempByteReceived = 0;*/
                                    //allDone.Set();
                                    handler.Shutdown(SocketShutdown.Both);
                                    handler.Disconnect(true);
                                    handler.Close();
                                    handler.Dispose();
                                    return;
                                }
                            }
                        }//if
                        else
                        {
                            curMsg = "Saving Data...";
                            writer.Write(state.buffer, 48, sendingByte);
                            writer.Close();
                            //
                            //send ACK
                            sendDone.Reset();
                            SendAcknowledge(state);
                            sendDone.WaitOne();
                            //flag++;
                            state.flag++;
                            try
                            {
                                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                new AsyncCallback(ReadCallback1), state);
                            }
                            catch (SocketException e)
                            {
                                if (!handler.Connected)
                                {
                                    //MessageBox.Show(Properties.Resources.DisconnectMsg);

                                    if (trace)
                                    {
                                        Trace.WriteLine("Disconnect from client due to error " + e.Message);
                                    }
                                    /*flag = 0;
                                    receiveRetry = 0;
                                    totalByteReceived = 0;
                                    tempByteReceived = 0;*/
                                    //allDone.Set();

                                    handler.Shutdown(SocketShutdown.Both);
                                    handler.Disconnect(true);
                                    handler.Close();
                                    handler.Dispose();
                                    return;
                                }
                            }
                        }//else
                    }
            
                }// if(flag >= 1)
            }
            else // byteReads == 0
            {
                
                //if (receiveRetry != 10)
                if(state.receivedRetry != 10)
                {
                    //receiveRetry++;
                    state.receivedRetry++;
                    try
                    {
                        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReadCallback1), state);
                    }
                    catch(SocketException e)
                    {
                        if (!handler.Connected)
                        {
                            //MessageBox.Show(Properties.Resources.DisconnectMsg);
                            if (trace)
                            {
                                Trace.WriteLine("Disconnect from client due to error " + e.Message);
                            }
                            /*flag = 0;
                            receiveRetry = 0;
                            totalByteReceived = 0;
                            tempByteReceived = 0;*/
                            //allDone.Set();
                            handler.Shutdown(SocketShutdown.Both);
                            handler.Disconnect(true);
                            handler.Close();
                            handler.Dispose();
                            return;
                        }
                    }
                }
                else
                {
                    if (trace)
                    {
                        Trace.WriteLine("Fail to received " + " from " + ipEndPoint.ToString());
                    }
                    /*receiveRetry = 0;
                    flag = 0;
                    totalByteReceived = 0;
                    totalByteReceived = 0;*/
                    //allDone.Set();
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Disconnect(true);
                    handler.Close();
                    handler.Dispose();
                    return;
                    
                }
                

            }
        }

        //
        //Function to send data to clients
        //

        public static void SendAcknowledge(StateObject stateObject)
        {
            curMsg = "ACK sending...";

            Socket handler = stateObject.workSocket;
            IPEndPoint ipEndPoint = handler.RemoteEndPoint as IPEndPoint;

            // Trace
            if (trace)
            {
                Trace.WriteLine("Sending ACK to " + ipEndPoint.ToString());
            }

        
            int sizeACK = 6;
            byte[] buffer = new byte[sizeACK];
            buffer[0] = 0x06;
            buffer[1] = 0;
            buffer[2] = 0;
            buffer[3] = 0;
            buffer[4] = 0;
            buffer[5] = 0x03;
            try
            {
                handler.BeginSend(buffer, 0, sizeACK, SocketFlags.None, new AsyncCallback(SendCallBackACK), handler);
            }
            catch (SocketException e)
            {
                if (!handler.Connected)
                {
                    curMsg = "Fail to send ACK...";
                    if (trace)
                    {
                        Trace.WriteLine("Disconnect from client due to error " + e.Message);

                    }
                    sendDone.Set();
                }
            }

        }

        private static void SendCallBackACK(IAsyncResult ar)
        {
            Socket handler = null;
            handler = (Socket)ar.AsyncState;
            IPEndPoint ipEndPoint = handler.RemoteEndPoint as IPEndPoint;
            try
            {
                int byteSent = handler.EndSend(ar);
                if (byteSent != 0)
                {
                    curMsg = "Finishing sending ACK...";
                    if (trace)
                    {
                        Trace.WriteLine("Finish Sending ACK to " + ipEndPoint.ToString());
                    }
                    sendDone.Set();
                }
            }
            catch (SocketException e)
            {
                if (trace)
                {
                    Trace.WriteLine("Disconnect from client due to error " + e.Message);
                    
                }
                sendDone.Set();
            }
           
        }

        ///
        /// This function is used to send a command to request sending sigle file
        ///
        
        public static void SendSingleFileCommand(string fileType, string requiredDateTime, string clientCode)
        {
            IList<String> removedItems = new List<String>();
            IList<Socket> closedSockets = new List<Socket>();
            byte[] bufferSend = null;
            int sizeOfCommand = 0;

            if (string.Equals(fileType, "DMPF", StringComparison.OrdinalIgnoreCase) || string.Equals(fileType, "DMPW", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(fileType, "DMPO", StringComparison.OrdinalIgnoreCase) || string.Equals(fileType, "DMP3", StringComparison.OrdinalIgnoreCase))
            {
           
                sizeOfCommand = 54;
                string tempMonth;
                string tempDay;
                string tempHour;
                string tempMinute;
                string tempSecond;
                //string DateTime;
                bufferSend = new byte[sizeOfCommand];
                //STX
                bufferSend[0] = 0x02;
                //Sequence Number
                bufferSend[1] = 0;
                bufferSend[2] = 0;
                bufferSend[3] = 0;
                bufferSend[4] = 0;
                //Command size
                bufferSend[5] = 12;
                bufferSend[6] = 0;
                //Data block size
                bufferSend[7] = 0x1D;
                bufferSend[8] = 0;
                //"A"
                bufferSend[9] = 0x41;
                //client code
                byte[] code = Encoding.ASCII.GetBytes(clientCode);
                code.CopyTo(bufferSend, 10);
                //reportID
                byte[] reportID = Encoding.ASCII.GetBytes(fileType);
                reportID.CopyTo(bufferSend, 17);
                //Sub command or type of command
                Encoding.ASCII.GetBytes("F").CopyTo(bufferSend,21);

                //
                DateTime now = DateTime.Now;
           
                if (now.Month < 10)
                {
                    tempMonth = "0" + now.Month.ToString();
                }
                else
                {
                    tempMonth = now.Month.ToString();
                }
                if (now.Day < 10)
                {
                    tempDay = "0" + now.Day.ToString();
                }
                else
                {
                    tempDay = now.Day.ToString();
                }
                if (now.Hour < 10)
                {
                    tempHour = "0" + now.Hour.ToString();
                }
                else
                {
                    tempHour = now.Hour.ToString();
                }
                if (now.Minute < 10)
                {
                    tempMinute = "0" + now.Minute.ToString();
                }
                else
                {
                    tempMinute = now.Minute.ToString();
                }
                if (now.Second < 10)
                {
                    tempSecond = "0" + now.Second.ToString();
                }
                else
                {
                    tempSecond = now.Second.ToString();
                }
                string dateTimeStr = now.Year.ToString() + tempMonth + tempDay + tempHour + tempMinute + tempSecond;
                byte[] temp_DateTime = Encoding.ASCII.GetBytes(dateTimeStr);
                //Command Date
                temp_DateTime.CopyTo(bufferSend, 22);
                //filename
                Encoding.ASCII.GetBytes(requiredDateTime).CopyTo(bufferSend, 36);
                // ETX
                bufferSend[50] = 0x03; 
                //CRC
                bufferSend[51] = 0;
                bufferSend[52] = 0;
                //CR
                bufferSend[53] = 0;
            }// if
            else if (string.Equals(fileType, "DMPL", StringComparison.OrdinalIgnoreCase) || string.Equals(fileType, "SETT", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(fileType, "SETB", StringComparison.OrdinalIgnoreCase) || string.Equals(fileType, "SETM", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
            ///
            //allSendCommandDone.Reset();
            foreach (KeyValuePair<Socket, IPEndPoint> kvp in ClientsToSend)
            {
                Socket handler = kvp.Key;
                IPEndPoint ipEndPoint = kvp.Value;
                closedSockets.Add(handler);
                try
                {
                    if (trace)
                    {
                        Trace.WriteLine("Sending " + fileType + " command to client " + ipEndPoint.ToString());
                    }
                    sendCommandDone.Set();
                    handler.BeginSend(bufferSend, 0, sizeOfCommand, SocketFlags.None, new AsyncCallback(SendCommandCallBack), handler);
                    sendCommandDone.WaitOne();

                   
                }
                catch (SocketException e)
                {
                    if (!handler.Connected)
                    {
                        
                        /*if (trace)
                        {
                            Trace.WriteLine("Disconnect from client due to error " + e.Message);

                        }*/
                        
                        MessageBox.Show("The client already closed the socket, wait for another time");
                        removedItems.Add(ipEndPoint.ToString());
                        RemoveClientItem(removedItems);
                        
                        removedItems.Clear();
                        RemoveClient(closedSockets);
                        closedSockets.Clear();
                        sendCommandDone.Set();
                        //allSendCommandDone.Set();
                        serverSendCommand.BeginInvoke(new EnableButtonSendingCommmand(serverSendCommand.btnSendingCommand_Enable));
                        return;
                    }
                }
            }//foreach
            RemoveClient(closedSockets);
            closedSockets.Clear();
            serverSendCommand.BeginInvoke(new EnableButtonSendingCommmand(serverSendCommand.btnSendingCommand_Enable));
            //allSendCommandDone.Set();
        }

        public static void SendTimePeriodCommand(string fileType, string requiredFromTime, string requiredToTime, string clientCode)
        {
            IList<String> removedItems = new List<String>();
            IList<Socket> closedSockets = new List<Socket>();

            byte[] bufferSend = null;
            int sizeOfCommand = 0;

            if (string.Equals(fileType, "DMPF", StringComparison.OrdinalIgnoreCase) || string.Equals(fileType, "DMPW", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(fileType, "DMPO", StringComparison.OrdinalIgnoreCase) || string.Equals(fileType, "DMP3", StringComparison.OrdinalIgnoreCase))
            {

                sizeOfCommand = 68;
                string tempMonth;
                string tempDay;
                string tempHour;
                string tempMinute;
                string tempSecond;
                //string DateTime;
                bufferSend = new byte[sizeOfCommand];
                //STX
                bufferSend[0] = 0x02;
                //Sequence Number
                bufferSend[1] = 0;
                bufferSend[2] = 0;
                bufferSend[3] = 0;
                bufferSend[4] = 0;
                //Command size
                bufferSend[5] = 12;
                bufferSend[6] = 0;
                //Data block size
                bufferSend[7] = 43;
                bufferSend[8] = 0;
                //"A"
                bufferSend[9] = 0x41;
                //client code
                byte[] code = Encoding.ASCII.GetBytes(clientCode);
                code.CopyTo(bufferSend, 10);
                //reportID
                byte[] reportID = Encoding.ASCII.GetBytes(fileType);
                reportID.CopyTo(bufferSend, 17);
                //Sub command or type of command
                Encoding.ASCII.GetBytes("P").CopyTo(bufferSend, 21);

                //
                DateTime now = DateTime.Now;

                if (now.Month < 10)
                {
                    tempMonth = "0" + now.Month.ToString();
                }
                else
                {
                    tempMonth = now.Month.ToString();
                }
                if (now.Day < 10)
                {
                    tempDay = "0" + now.Day.ToString();
                }
                else
                {
                    tempDay = now.Day.ToString();
                }
                if (now.Hour < 10)
                {
                    tempHour = "0" + now.Hour.ToString();
                }
                else
                {
                    tempHour = now.Hour.ToString();
                }
                if (now.Minute < 10)
                {
                    tempMinute = "0" + now.Minute.ToString();
                }
                else
                {
                    tempMinute = now.Minute.ToString();
                }
                if (now.Second < 10)
                {
                    tempSecond = "0" + now.Second.ToString();
                }
                else
                {
                    tempSecond = now.Second.ToString();
                }
                string dateTimeStr = now.Year.ToString() + tempMonth + tempDay + tempHour + tempMinute + tempSecond;
                
                //startTime
                Encoding.ASCII.GetBytes(requiredFromTime).CopyTo(bufferSend, 22);

                // EndTIme

                Encoding.ASCII.GetBytes(requiredToTime).CopyTo(bufferSend, 36);



                byte[] temp_DateTime = Encoding.ASCII.GetBytes(dateTimeStr);
                //Command Date
                temp_DateTime.CopyTo(bufferSend, 50);

                // ETX
                bufferSend[64] = 0x03;
                //CRC
                bufferSend[65] = 0;
                bufferSend[66] = 0;
                //CR
                bufferSend[67] = 0;
            }// if
            else if (string.Equals(fileType, "DMPL", StringComparison.OrdinalIgnoreCase) || string.Equals(fileType, "SETT", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(fileType, "SETB", StringComparison.OrdinalIgnoreCase) || string.Equals(fileType, "SETM", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
            ///
            //allSendCommandDone.Reset();
            foreach (KeyValuePair<Socket, IPEndPoint> kvp in ClientsToSend)
            {
                Socket handler = kvp.Key;
                IPEndPoint ipEndPoint = kvp.Value;
                closedSockets.Add(handler);
                try
                {
                    if (trace)
                    {
                        Trace.WriteLine("Sending " + fileType + " command to client " + ipEndPoint.ToString());
                    }
                    sendCommandDone.Reset();
                    handler.BeginSend(bufferSend, 0, sizeOfCommand, SocketFlags.None, new AsyncCallback(SendCommandCallBack), handler);
                    sendCommandDone.WaitOne();
                    
                    
                }
                catch (SocketException e)
                {
                    if (!handler.Connected)
                    {

                        /*if (trace)
                        {
                            Trace.WriteLine("Disconnect from client due to error " + e.Message);

                        }*/
                        
                        MessageBox.Show("The client already closed the socket, wait for another time");
                        removedItems.Add(ipEndPoint.ToString());
                        RemoveClientItem(removedItems);

                        removedItems.Clear();
                        RemoveClient(closedSockets);
                        closedSockets.Clear();
                        serverSendCommand.BeginInvoke(new EnableButtonSendingCommmand(serverSendCommand.btnSendingCommand_Enable));
                        sendCommandDone.Set();
                        //allSendCommandDone.Set();
                        return;
                    }
                }
            }//foreach
            RemoveClient(closedSockets);
            closedSockets.Clear();
            serverSendCommand.BeginInvoke(new EnableButtonSendingCommmand(serverSendCommand.btnSendingCommand_Enable));
            //allSendCommandDone.Set();
        }



        private static void SendCommandCallBack(IAsyncResult ar)
        {
            Socket handler = null;
            handler = (Socket)ar.AsyncState;
            IPEndPoint ipEndPoint = handler.RemoteEndPoint as IPEndPoint;
            try
            {
                int byteSent = handler.EndSend(ar);
                if (byteSent != 0)
                {
                    if (trace)
                    {
                        Trace.WriteLine("Finish sending command to client " + ipEndPoint.ToString());
                    }
                    MessageBox.Show("Finish sending command to client");
                    sendCommandDone.Set();
                }
            }
            catch (SocketException e)
            {
                /*if (trace)
                {
                    Trace.WriteLine("Disconnect from client due to error " + e.Message);

                }*/
                MessageBox.Show("Disconnect from client due to error " + e.Message);
                sendCommandDone.Set();
            }

        }
        /// <summary>
        /// Change the presentation of listbox when the some clients disconnect the connection.
        /// </summary>
        /// <param name="ipAddressList"></param>
        private static void RemoveClientItem(IList<String> ipAddressList)
        {
            foreach (string ipAddress in ipAddressList)
            {
                Server.BeginInvoke(new RemoveItemHandler(serverSendCommand.RemoveItem), ipAddress);
            }

            
        }


        /// <summary>
        /// Remove the sockets if some client disconnect the connection in Remote Control.
        /// </summary>
        /// <param name="listSocket"></param>
        /// 
        private static void RemoveClientItemInRemoteControl(IList<String> ipAddressList)
        {
            foreach (string ipAddress in ipAddressList)
            {
                remoteControlCommand.BeginInvoke(new RemoveItemHandler(remoteControlCommand.RemoveItem), ipAddress);
            }


        }

        /// <summary>
        /// Remove the sockets if some client disconnect the connection in Sending Command
        /// </summary>
        /// <param name="listSocket"></param>
        private static void RemoveClient(IList<Socket> listSocket)
        {
            if (listSocket.Count > 0)
            {
                foreach (Socket socket in listSocket)
                {
                    //Clients.Remove(socket);
                    ClientsToSend.Remove(socket);
                }
            }
        }

        /// <summary>
        /// Function to send SETT Command to clients
        /// </summary>
        /// <param name="requiredDateTime"></param>
        /// <param name="clientCode"></param>
        public static void SendSETTCommand(string requiredDateTime, string clientCode)
        {
            IList<String> removedItems = new List<String>();
            IList<Socket> closedSockets = new List<Socket>();
            byte[] bufferSend = null;
            int sizeOfCommand = 0;
            sizeOfCommand = 39;

            //string DateTime;
            bufferSend = new byte[sizeOfCommand];
            //STX
            bufferSend[0] = 0x02;
            //Sequence Number
            bufferSend[1] = 0;
            bufferSend[2] = 0;
            bufferSend[3] = 0;
            bufferSend[4] = 0;
            //Command size
            bufferSend[5] = 12;
            bufferSend[6] = 0;
            //Data block size
            bufferSend[7] = 0xE;
            bufferSend[8] = 0;
            //"A"
            bufferSend[9] = 0x41;
            //client code
            byte[] code = Encoding.ASCII.GetBytes(clientCode);
            code.CopyTo(bufferSend, 10);
            //reportID
            byte[] reportID = Encoding.ASCII.GetBytes("SETT");
            reportID.CopyTo(bufferSend, 17);

            //required time
            Encoding.ASCII.GetBytes(requiredDateTime).CopyTo(bufferSend, 21);
            // ETX
            bufferSend[35] = 0x03;
            //CRC
            bufferSend[36] = 0;
            bufferSend[37] = 0;
            //CR
            bufferSend[38] = 0;

            foreach (KeyValuePair<Socket, IPEndPoint> kvp in ClientsToSend)
            {
                Socket handler = kvp.Key;
                IPEndPoint ipEndPoint = kvp.Value;
                closedSockets.Add(handler);
                try
                {
                    if (trace)
                    {
                        Trace.WriteLine("Sending SETT" + " command to client " + ipEndPoint.ToString());
                    }
                    sendCommandDone.Set();
                    handler.BeginSend(bufferSend, 0, sizeOfCommand, SocketFlags.None, new AsyncCallback(SendCommandCallBack), handler);
                    sendCommandDone.WaitOne();


                }
                catch (SocketException e)
                {
                    if (!handler.Connected)
                    {

                        /*if (trace)
                        {
                            Trace.WriteLine("Disconnect from client due to error " + e.Message);

                        }*/

                        MessageBox.Show("The client already closed the socket, wait for another time");
                        removedItems.Add(ipEndPoint.ToString());
                        //RemoveClientItem(removedItems);
                        RemoveClientItemInRemoteControl(removedItems);

                        removedItems.Clear();
                        RemoveClient(closedSockets);
                        closedSockets.Clear();
                        sendCommandDone.Set();
                        
                        return;
                    }
                }
            }//foreach
            RemoveClient(closedSockets);
            closedSockets.Clear();
            
        }

        #endregion

    }
}
