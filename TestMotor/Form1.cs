﻿using System;
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
            InitializeComponent();
            this.driveCtrlView.DriveCtrl = new DriveCtrl(Constants.IODriveCtrl);
            this.motorCtrlViewLeft.MotorCtrl = new MotorCtrl(Constants.IOMotorCtrlLeft);           
            this.motorCtrlViewRight.MotorCtrl = new MotorCtrl(Constants.IOMotorCtrlRight);
        }
    }
}
