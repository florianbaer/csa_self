using RobotCtrl;
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
        private Driver driver;
        private Thread tcpThread;
        HttpLogServer httpLogServer;
        private Thread httpLogServerThread;

        

        public Form1()
        {
            InitializeComponent();

            robot = new Robot();
            robot.Drive.Power = true;
            this.BootstrapRoboCop();
        }

        private void BootstrapRoboCop()
        {
            httpLogServer = new HttpLogServer(httpPort);
            httpLogServerThread = new Thread(httpLogServer.Start);

            driver = new Driver(robot, this.httpLogServerThread, this.httpLogServer, this.tbLog);

            tcpServer = new TcpServer(port, driver, httpLogServerThread);
            tcpThread = new Thread(tcpServer.Start);
            
            tcpServer.Log += driver.httpServerLogEvent;
            

            tcpThread.Start();
        }

        private void ResetThreads()
        {
            driveThread = new Thread(driver.Drive);
            tcpThread = new Thread(tcpServer.Start);
        }





        protected override void OnClosing(CancelEventArgs e)
        {
            this.robot.Drive.Power = false;
            this.robot.Dispose();
            this.tcpThread?.Abort();
            this.driveThread?.Abort();
            this.httpLogServerThread?.Abort();
            base.OnClosing(e);
        }
    }
}
