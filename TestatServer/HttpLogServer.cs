using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TestatServer
{
    public class HttpLogServer
    {
        private int httpPort;
        TcpListener tcpListener;

        public HttpLogServer(int httpPort)
        {
            this.httpPort = httpPort;

            tcpListener = new TcpListener(IPAddress.Any, this.httpPort);
        }

        public void Start()
        {
            tcpListener.Start();
            while (true)
            {
                using (TcpClient client = tcpListener.AcceptTcpClient())
                {
                    using (NetworkStream stream = client.GetStream())
                    {
                        //if (client.ReceiveBufferSize > 0)
                        {
                            StreamReader inputStream = new StreamReader(client.GetStream());
                            StreamWriter outputStream = new StreamWriter(client.GetStream());
                            string request = inputStream.ReadLine();


                            StringBuilder builder = new StringBuilder();
                            builder.AppendLine(@"HTTP/1.1 200 OK");
                            builder.AppendLine(@"Content-Type: text/csv");
                            builder.AppendLine("Content-Disposition: attachment; filename =\"LogFile.csv\"");
                            builder.AppendLine(@"");
                            using (StreamReader reader = new StreamReader(FileConstants.LogFileUrl))
                            {
                                builder.AppendLine(reader.ReadToEnd());
                            }

                            outputStream.WriteLine(builder.ToString());
                            outputStream.Flush();
                            inputStream.Close();
                            outputStream.Close();
                        }
                    }
                }
            }

        }
    }
}