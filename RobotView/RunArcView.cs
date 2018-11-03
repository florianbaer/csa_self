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
    public partial class RunArcView : UserControl
    {
        private float radius;
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

        public RunArcView()
        {
            InitializeComponent();
            radius = (float)npRadius.Value;
            angle = (float)npAngle.Value;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (rbLeft.Checked)
            {
                Drive.RunArcLeft(radius / 1000, angle, speed, acceleration);
            }
            else
            {
                Drive.RunArcRight(radius / 1000, angle, speed, acceleration);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            radius *= -1;
            npRadius.Value = (int)radius;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            angle *= -1;
            npAngle.Value = (int)angle;
        }

        private void npRadius_ValueChanged(object sender, EventArgs e)
        {
            radius = (float)npRadius.Value;
        }

        private void npAngle_ValueChanged(object sender, EventArgs e)
        {
            angle = (float)npAngle.Value;
        }
    }
}