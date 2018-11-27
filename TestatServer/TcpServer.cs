using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TestatServer
{
    public class TcpServer
    {
        TcpListener tcpListener;
        public event EventHandler Log;
        bool isActive;
        CommandsXml xml;

        public TcpServer(int port)
        {
            tcpListener = new TcpListener(IPAddress.Any, port);
            xml = new CommandsXml();
        }

        public void Start()
        {
            isActive = true;
            tcpListener.Start();
            Log?.Invoke("Tcp Server started", new EventArgs());

            while (isActive)
            {
                TcpClient client = tcpListener.AcceptTcpClient();

                NetworkStream stream = client.GetStream();

                if (client.ReceiveBufferSize > 0)
                {
                    StreamReader inputStream = new StreamReader(client.GetStream());
                    StreamWriter outputStream = new StreamWriter(client.GetStream());
                    string request = inputStream.ReadLine();
                    inputStream.Close();

                    Log?.Invoke(request, new EventArgs());
                    isActive = HandleRequest(request);


                    outputStream.WriteLine("OK");
                    outputStream.Flush();
                    outputStream.Close();
                }
            }

            CommandsXml.WriteXml(xml);
        }

        private bool HandleRequest(string request)
        {
            RobotCommand rc = null;

            if (request.StartsWith("TrackLine"))
            {
                rc = new TrackTurnCommand();
            }
            else if(request.StartsWith("Start"))
            {
                return false;
            }

            xml.Commands.Enqueue(rc);

            return true;
        }
    }
}
