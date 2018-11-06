using RobotCtrl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TestatDrive
{
    public class ObstacleRecognizer
    {
        private float previousDistance = 255f;
        public event EventHandler<EventArgs> obstacleDetectedEvent;

        public void Execute(Robot robot)
        {
            while (Thread.CurrentThread.IsAlive)
            {
                float currentDistance = robot.Radar.Distance;
                if (currentDistance < 1.0f && previousDistance >= 1.0f)
                {
                    //Event 
                    obstacleDetectedEvent?.Invoke(this, new EventArgs());
                }
                previousDistance = currentDistance;

                Thread.Sleep(50);
            }
        }
    }
}
