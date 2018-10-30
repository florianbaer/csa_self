using RobotCtrl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestDrive
{
    public partial class Form1 : Form
    {
        private Robot robot;

        public Form1()
        {
            InitializeComponent();

            robot = new Robot();
            robot.Drive.Power = true;

            runLineView1.Drive = robot.Drive;
            runLineView1.Speed = commonRunParameters1.Speed;
            runLineView1.Acceleration = commonRunParameters1.Acceleration;

            runArcView1.Drive = robot.Drive;
            runArcView1.Speed = commonRunParameters1.Speed;
            runArcView1.Acceleration = commonRunParameters1.Acceleration;

            runTurnView1.Drive = robot.Drive;
            runTurnView1.Speed = commonRunParameters1.Speed;
            runTurnView1.Acceleration = commonRunParameters1.Acceleration;

            driveView1.Drive = robot.Drive;
        }

        private void commonRunParameters1_SpeedChanged(object sender, EventArgs e)
        {
            runLineView1.Speed = commonRunParameters1.Speed;
            runArcView1.Speed = commonRunParameters1.Speed;
            runTurnView1.Speed = commonRunParameters1.Speed;
        }

        private void commonRunParameters1_AccelerationChanged(object sender, EventArgs e)
        {
            runLineView1.Acceleration = commonRunParameters1.Acceleration;
            runArcView1.Acceleration = commonRunParameters1.Acceleration;
            runTurnView1.Acceleration = commonRunParameters1.Acceleration;
        }
    }
}
