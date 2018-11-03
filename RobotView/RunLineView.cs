using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using RobotCtrl;

namespace RobotView
{
    public partial class RunLineView : UserControl
    {
        private float length;
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


        public RunLineView()
        {
            InitializeComponent();
            length = (float)npDistance.Value;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Drive.RunLine(length / 1000, speed, acceleration);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            length *= -1;
            npDistance.Value = (int)length;
        }

        private void npDistance_ValueChanged(object sender, EventArgs e)
        {
            length = (float)npDistance.Value;
        }
    }
}
