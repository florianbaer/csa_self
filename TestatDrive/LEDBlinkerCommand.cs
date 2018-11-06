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
        private int currentLed = 0;


        public void Execute(Robot robot)
        {
            while (Thread.CurrentThread.IsAlive)
            {
                //for(int i = 0; i<4; i++)
                //{
                //    robot.RobotConsole[(LEDPin) i].LedEnabled = !robot.RobotConsole[(LEDPin)i].LedEnabled;
                //}

                robot.RobotConsole[(LEDPin)currentLed].LedEnabled = false;

                currentLed++;
                if(currentLed == 4)
                {
                    currentLed = 0;
                }

                robot.RobotConsole[(LEDPin)currentLed].LedEnabled = true;

                Thread.Sleep(200);
            }
        }
    }
}
