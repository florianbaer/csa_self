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
    public partial class LedView : UserControl
    {
        private bool state = false;
        private Led ledComponent;

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

        public Led LedComponent
        {
            get
            {
                return ledComponent;
            }
            set
            {
                this.ledComponent = value;
                //this.ledComponent.LedStateChanged += this.OnLedStateChanged;
            }
        }

        public LedView()
        {
            InitializeComponent();
        }

        public void ChangeImageEvent()
        {
            if (this.state)
            {
                statePictureBox.Image = Images.LedOn;
            }
            else
            {
                statePictureBox.Image = Images.LedOff;
            }
        }

        private delegate void ChangeImage();

        public void RefreshImageView()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ChangeImage(ChangeImageEvent));
            }
        }

        public void OnLedStateChanged(object sender, SwitchEventArgs e)
        {
            this.State = !this.State;
        }
    }
}