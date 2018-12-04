using System;
using System.Threading;
using System.Windows.Forms;
using RobotCtrl;

namespace TestatServer
{
    public class Driver
    {
        private HttpLogServer httpLogServer;
        private Thread httpLogServerThread;
        private Thread logThread;
        private Robot robot;
        private TextBox tbLog;
        private LogPosition positionLogger;


        public Driver(Robot robot, Thread httpLogServerThread, HttpLogServer httpLogServer,
            TextBox tblog)
        {
            this.robot = robot;
            this.positionLogger = new LogPosition(this.robot);
            this.httpLogServerThread = httpLogServerThread;
            this.httpLogServer = httpLogServer;
            this.tbLog = tblog;
        }


        private void SetLabel(string log)
        {
            tbLog.Text += log.ToString() + Environment.NewLine;
        }

        public delegate void AddLog(string log);

        public void Drive()
        {
            this.logThread = new Thread(positionLogger.Start); ;
            this.logThread.Start();

            foreach (RobotCommand command in DriveCommand.ReadCommands())
            {
                command.Execute(this.robot);
                tbLog.BeginInvoke(new AddLog(SetLabel), new object[] { command.ToString() + " started" });
                while (!this.robot.Drive.Done)
                {
                    Thread.Sleep(100);
                };
            }

            this.logThread.Abort();
            httpLogServerThread = new Thread(httpLogServer.Start);
            this.httpLogServerThread.Start();
        }


        public void httpServerLogEvent(object sender, EventArgs e)
        {
            if (tbLog.InvokeRequired)
            {
                tbLog.BeginInvoke(new Driver.AddLog(SetLabel), new object[] { sender.ToString() });
            }
        }

    }
}