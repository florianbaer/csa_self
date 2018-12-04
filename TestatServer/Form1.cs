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
            this.robot.Drive.Power = true;
            this.BootstrapRoboCop();
        }

        private void BootstrapRoboCop()
        {
            //Alle benötigten Threads erzeugen
            driveThread = new Thread(driver.Drive);
            driver = new Driver(this.robot, this.httpLogServerThread, this.httpLogServer, this.tbLog);
            //tcp Server starten
            tcpServer = new TcpServer(port, driveThread, httpLogServerThread);
            tcpServer.Log += driver.httpServerLogEvent;

            httpLogServer = new HttpLogServer(httpPort);

            tcpThread = new Thread(tcpServer.Start);
            httpLogServerThread = new Thread(httpLogServer.Start);

            tcpThread.Start();
        }

        private void ResetThreads()
        {
            driveThread = new Thread(driver.Drive);
            tcpThread = new Thread(tcpServer.Start);
        }





        protected override void OnClosing(CancelEventArgs e)
        {
            this.tcpThread?.Abort();
            this.driveThread?.Abort();
            this.httpLogServerThread?.Abort();
            base.OnClosing(e);
        }
    }
}
