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
            logPosition = new LogPosition(this.robot);

            //Alle benötigten Threads erzeugen
            driveThread = new Thread(new ThreadStart(Drive));

            //tcp Server starten
            tcpServer = new TcpServer(port, driveThread);
            tcpServer.Log += new EventHandler(httpServerLogEvent);

            logThread = new Thread(new ThreadStart(logPosition.Start));
            tcpThread = new Thread(new ThreadStart(tcpServer.Start));


            tcpThread.Start();          
        }

        private void Drive()
        {
            logThread.Start();
            this.robot.Drive.Power = true;

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
