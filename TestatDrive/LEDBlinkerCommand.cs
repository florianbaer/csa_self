using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using RobotCtrl;

namespace TestatDrive
{
    public class LEDBlinkerCommand
    {
        public void Execute(Robot robot)
        {
            while (Thread.CurrentThread.IsAlive)
            {
                for(int i = 0; i<4; i++)
                {
                    robot.RobotConsole[(LEDPin) i].LedEnabled = !robot.RobotConsole[(LEDPin)i].LedEnabled;
                }
            }
        }
    }
}
