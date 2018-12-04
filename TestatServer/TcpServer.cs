using RobotCtrl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TestatServer
{
    public class TcpServer
    {
        TcpListener tcpListener;
        public event EventHandler Log;
        bool isActive;
        Thread driveThread;
        Thread httpThread;

        public TcpServer(int port, Thread driveThread, Thread httpThread)
        {
            this.driveThread = driveThread;
            this.httpThread = httpThread;
            tcpListener = new TcpListener(IPAddress.Any, port);
            DriveCommand.CreateFile();
        }

        public void Start()
        {
            isActive = true;
            tcpListener.Start();
            Log?.Invoke("Tcp Server started", new EventArgs());

            while (isActive)
            {
                using (TcpClient client = tcpListener.AcceptTcpClient())
                {
                    using (NetworkStream stream = client.GetStream())
                    {
                        if (client.ReceiveBufferSize > 0)
                        {
                            StreamReader inputStream = new StreamReader(client.GetStream());
                            StreamWriter outputStream = new StreamWriter(client.GetStream());
                            string request = inputStream.ReadLine();

                            Log?.Invoke(request, new EventArgs());
                            isActive = HandleRequest(request);


                            outputStream.WriteLine("OK");
                            outputStream.Flush();
                            inputStream.Close();
                            outputStream.Close();
                        }
                    }                        
                }                    
            }
            this.driveThread.Start();
        }

        private bool HandleRequest(string request)
        {
            if (httpThread != null && httpThread.IsAlive)
            {
                httpThread?.Abort();
            }

            DriveCommand.AppendCommand(request);

            if(request.StartsWith("Start"))
            {
                return false;
            }
            return true;
        }
    }
}
