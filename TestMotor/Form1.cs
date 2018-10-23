using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RobotCtrl;
using RobotView;

namespace TestMotor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.driveCtrlView1 = new DriveCtrlView();
            this.driveCtrlView1.DriveCtrl = new DriveCtrl(Constants.IODriveCtrl);

            this.motorCtrlView1 = new MotorCtrlView();
            this.motorCtrlView1.MotorCtrl = new MotorCtrl(Constants.IOMotorCtrlLeft);

            this.motorCtrlView2 = new MotorCtrlView();
            this.motorCtrlView2.MotorCtrl = new MotorCtrl(Constants.IOMotorCtrlRight);
            InitializeComponent();
        }
    }
}
