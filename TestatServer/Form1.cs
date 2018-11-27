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
        private TcpServer tcpServer;
        private Robot robot;
        private Thread driveThread;
        private Thread logThread;
        private Thread tcpThread;
        private LogPosition logPosition;

        public Form1()
        {
            InitializeComponent();

            robot = new Robot();

            //Start drive
            driveThread = new Thread(new ThreadStart(Drive));
            logPosition = new LogPosition(this.robot);
            logThread = new Thread(new ThreadStart(logPosition.Start));

            tcpServer = new TcpServer(port, driveThread);
            tcpServer.Log += new EventHandler(httpServerLogEvent);

            tcpThread = new Thread(new ThreadStart(tcpServer.Start));
            tcpThread.Start();          
        }

        private void Drive()
        {
            logThread.Start();

            foreach (RobotCommand command in DriveCommand.ReadCommands())
            {
                command.Execute(this.robot);
                while (!this.robot.Drive.Done)
                {
                    Thread.Sleep(100);
                };
            }

            logThread.Abort();
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
            base.OnClosing(e);
        }
    }
}
