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
    public partial class SwitchView : UserControl
    {
        private bool state = false;
        private Switch switchComponent;

        public bool State
        {
            get
            {
                return state;
            }
            set
            {
                this.state = value;
                this.RefreshImageView();
            }
        }

        public Switch SwitchComponent
        {
            get
            {
                return switchComponent;
            }
            set
            {
                this.switchComponent = value;
                this.switchComponent.SwitchStateChanged += OnSwitchStateChanged;
            }
        }

        public SwitchView()
        {
            InitializeComponent();
        }

        public void RefreshImageView()
        {
            if (this.state)
            {
                statePictureBox.Image = Images.SwitchOn;
            }
            else
            {
                statePictureBox.Image = Images.SwitchOff;
            }
            
        }

        private void OnSwitchStateChanged(object sender, SwitchEventArgs e)
        {
            this.State = e.SwitchEnabled;
        }

        private void statePictureBox_Click(object sender, EventArgs e)
        {
            
        }
    }
}