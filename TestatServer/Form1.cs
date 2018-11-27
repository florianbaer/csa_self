using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TestatServer
{
    public partial class Form1 : Form
    {
        int port = 80;
        TcpServer httpServer;

        public Form1()
        {
            InitializeComponent();

            httpServer = new TcpServer(port);
            httpServer.Log += new EventHandler(httpServerLogEvent);

            Thread thread = new Thread(new ThreadStart(httpServer.Start));
            thread.Start();

            thread.Join();
        }

        public void httpServerLogEvent(object sender, EventArgs e)
        {
            tbLog.Text += sender.ToString() + Environment.NewLine;
        }
    }
}
