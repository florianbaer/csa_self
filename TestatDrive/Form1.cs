using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using RobotCtrl;

namespace TestatDrive
{
    public partial class Form1 : Form
    {
        private Robot robot;
        private int counter;
        private Thread blinkThread;
        private Thread obstacleThread;
        private Thread driveThread;
        public bool notTurn
        {
            get
            {
                    return _notTurn;
             
            }
            set { _notTurn = value; }
        }

        ObstacleRecognizer or;
        private bool _notTurn;

        public Form1()
        {
            InitializeComponent();
            this.robot = new Robot();
            this.radarView1.Radar = this.robot.Radar;

            this.robot.RobotConsole[Switches.Switch2].SwitchStateChanged += StartTestatRun;
        }



        private void StartTestatRun(object sender, SwitchEventArgs e)
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new RunDelegate(Run));
            }
        }

        private delegate void RunDelegate();

        private void Run()
        {
            //Counter zurücksetzen
            counter = 0;
            this.robot.Drive.Power = true;

            if (robot.Drive.Done)
            {
                
                //Threads starten
                blinkThread = new Thread(new ThreadStart(LedBlinker));
                blinkThread.Start();

                obstacleThread = new Thread(new ThreadStart(ObstacleRecognizer));
                obstacleThread.Start();

                driveThread = new Thread(new ThreadStart(Runner));
                driveThread.Start();
             }
        }

        private delegate void ChangeCounter();

        
        private void SetLabel()
        {
            counter++;
            tbAnzahlObjekte.Text = counter.ToString();
        }
        

        private void LedBlinker()
        {
            new LEDBlinkerCommand().Execute(robot);
        }

        private void ObstacleRecognizer()
        {
            or = new ObstacleRecognizer();
            or.obstacleDetectedEvent += ObstacleDetected;
            or.Execute(robot);
        }
        

        private void Runner()
        {
            //Roboter starten

            this.notTurn = true;
            robot.Drive.RunLine(2.5f, 0.5f, 0.3f);
            while (!robot.Drive.Done)
            {
                Thread.Sleep(100);
            };
            this.notTurn = false;
            robot.Drive.RunTurn(180, 0.5f, 0.3f);
            while (!robot.Drive.Done)
            {
                Thread.Sleep(100);
            };
            this.notTurn = true;
            robot.Drive.RunLine(2.5f, 0.5f, 0.3f);
            while (!robot.Drive.Done)
            {
                Thread.Sleep(100);
            };
            this.notTurn = false;
            robot.Drive.RunTurn(180, 0.5f, 0.3f);
            while (!robot.Drive.Done)
            {
                Thread.Sleep(100);
            };

            //Threads beenden
            blinkThread.Abort();
            obstacleThread.Abort();

            if (or != null)
            {
                or.obstacleDetectedEvent -= ObstacleDetected;
            }

            //Alle 4 LEDs leuchten zum Schluss
            for (int i = 0; i < 4; i++)
            {
                robot.RobotConsole[(LEDPin)i].LedEnabled = true;
            }
        }

        private void ObstacleDetected(object sender, EventArgs e)
        {

            if (notTurn)
            {
                if (this.InvokeRequired)
            {
                    this.tbAnzahlObjekte.BeginInvoke(new ChangeCounter(SetLabel));
                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.driveThread.Abort();
            this.obstacleThread.Abort();
            this.blinkThread.Abort();
            base.OnClosing(e);
        }
    }
}
