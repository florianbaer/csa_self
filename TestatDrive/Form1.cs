using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RobotCtrl;

namespace TestatDrive
{
    public partial class Form1 : Form
    {
        private Robot robot;
        public Form1()
        {
            InitializeComponent();
            this.robot = new Robot();

            this.robot.RobotConsole[Switches.Switch2].SwitchStateChanged += StartTestatRun;
        }

        private void StartTestatRun(object sender, SwitchEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
