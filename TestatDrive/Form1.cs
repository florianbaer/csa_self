using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using RobotCtrl;

namespace TestatDrive
{
    public partial class Form1 : Form
    {
        private Robot robot;
        private int counter;

        public Form1()
        {
            InitializeComponent();
            this.robot = new Robot();

            this.robot.RobotConsole[Switches.Switch2].SwitchStateChanged += StartTestatRun;
        }

        private void StartTestatRun(object sender, SwitchEventArgs e)
        {
            //Counter zurücksetzen
            counter = 0;
            tbAnzahlObjekte.Text = counter.ToString();

            if (robot.Drive.Done)
            {
                //Threads starten
                Thread blinkThread = new Thread(new ThreadStart(LedBlinker));
                blinkThread.Start();

                Thread obstacleThread = new Thread(new ThreadStart(ObstacleRecognizer));
                obstacleThread.Start();

                //Roboter starten
                robot.Drive.RunLine(2.5f, commonRunParameters1.Speed, commonRunParameters1.Acceleration);
                while (!robot.Drive.Done) ;
                robot.Drive.RunTurn(180, commonRunParameters1.Speed, commonRunParameters1.Acceleration);
                while (!robot.Drive.Done) ;
                robot.Drive.RunLine(2.5f, commonRunParameters1.Speed, commonRunParameters1.Acceleration);
                while (!robot.Drive.Done) ;
                robot.Drive.RunTurn(180, commonRunParameters1.Speed, commonRunParameters1.Acceleration);

                //Threads beenden
                blinkThread.Abort();
                obstacleThread.Abort();

                //Alle 4 LEDs leuchten zum Schluss
                for (int i = 0; i < 4; i++)
                {
                    robot.RobotConsole[(LEDPin)i].LedEnabled = true;
                }
            }
        }

        private void LedBlinker()
        {
            new LEDBlinkerCommand().Execute(robot);
        }

        private void ObstacleRecognizer()
        {
            ObstacleRecognizer or = new ObstacleRecognizer();
            or.obstacleDetectedEvent += new EventHandler<EventArgs>(ObstacleDetected);
            or.Execute(robot);
        }

        private void ObstacleDetected(object sender, EventArgs e)
        {
            counter++;
            tbAnzahlObjekte.Text = counter.ToString();
        }
    }
}
