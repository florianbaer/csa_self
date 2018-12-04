using RobotCtrl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TestatServer
{
    public partial class Form1 : Form
    {
        private int port = 1819;
        private int httpPort = 8080;
        private TcpServer tcpServer;
        private Robot robot;
        private Thread driveThread;
        private Thread logThread;
        private Thread tcpThread;
        HttpLogServer httpLogServer;
        private Thread httpLogServerThread;
        private LogPosition logPosition;

        public Form1()
        {
            InitializeComponent();

            robot = new Robot();
            logPosition = new LogPosition(this.robot);
            this.robot.Drive.Power = true;

            //Alle benötigten Threads erzeugen
            driveThread = new Thread(new ThreadStart(Drive));

            //tcp Server starten
            tcpServer = new TcpServer(port, driveThread, httpLogServerThread);
            tcpServer.Log += new EventHandler(httpServerLogEvent);

            httpLogServer = new HttpLogServer(httpPort);

            logThread = new Thread(new ThreadStart(logPosition.Start));
            tcpThread = new Thread(new ThreadStart(tcpServer.Start));
            httpLogServerThread = new Thread(new ThreadStart(httpLogServer.Start));

            tcpThread.Start();
        }

        private void ResetThreads()
        {
            driveThread = new Thread(new ThreadStart(Drive));
            logThread = new Thread(new ThreadStart(logPosition.Start));
            tcpThread = new Thread(new ThreadStart(tcpServer.Start));
        }


        private void Drive()
        {
            logThread.Start();            

            foreach (RobotCommand command in DriveCommand.ReadCommands())
            {
                command.Execute(this.robot);
                tbLog.BeginInvoke(new AddLog(SetLabel), new object[] { command.ToString() + " started" });
                while (!this.robot.Drive.Done)
                {
                    Thread.Sleep(100);
                };
            }

            logThread.Abort();
            httpLogServerThread = new Thread(new ThreadStart(httpLogServer.Start));
            this.httpLogServerThread.Start();
        }

        public void httpServerLogEvent(object sender, EventArgs e)
        {
            if(tbLog.InvokeRequired)
            {
                tbLog.BeginInvoke(new AddLog(SetLabel), new object[] { sender.ToString() });
            }            
        }

        private delegate void AddLog(string log);


        private void SetLabel(string log)
        {
            tbLog.Text += log.ToString() + Environment.NewLine;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.tcpThread?.Abort();
            this.logThread?.Abort();
            this.driveThread?.Abort();
            this.httpLogServerThread?.Abort();
            base.OnClosing(e);
        }
    }
}
