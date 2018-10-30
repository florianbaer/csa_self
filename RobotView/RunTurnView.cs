using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RobotCtrl;

namespace RobotView
{
    public partial class RunTurnView : UserControl
    {
        private float angle;
        private float speed;
        private float acceleration;

        public Drive Drive { get; set; }

        public float Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
            }
        }

        public float Acceleration
        {
            get
            {
                return acceleration;
            }

            set
            {
                acceleration = value;
            }
        }

        public RunTurnView()
        {
            InitializeComponent();
            angle = (float)npAngle.Value;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Drive.RunTurn(angle, speed, acceleration);
        }

        private void npAngle_ValueChanged(object sender, EventArgs e)
        {
            angle = (float)npAngle.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            angle *= -1;
            npAngle.Value = (int)angle;
        }
    }
}