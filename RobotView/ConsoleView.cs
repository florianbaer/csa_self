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
    public partial class ConsoleView : UserControl
    {
        private RobotConsole robotConsole;

        public RobotConsole RobotConsole
        {
            get
            {
                return robotConsole;
            }
            set
            {
                this.robotConsole = value;
                this.ledView1.LedComponent = this.robotConsole[LEDPin.Led1];
                this.ledView2.LedComponent = this.robotConsole[LEDPin.Led2];
                this.ledView3.LedComponent = this.robotConsole[LEDPin.Led3];
                this.ledView4.LedComponent = this.robotConsole[LEDPin.Led4];
                this.switchView1.SwitchComponent = this.robotConsole[Switches.Switch1];
                this.switchView2.SwitchComponent = this.robotConsole[Switches.Switch2];
                this.switchView3.SwitchComponent = this.robotConsole[Switches.Switch3];
                this.switchView4.SwitchComponent = this.robotConsole[Switches.Switch4];
            }
        }
        public ConsoleView()
        {
            InitializeComponent();
        }
    }
}