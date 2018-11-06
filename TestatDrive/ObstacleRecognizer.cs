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
                if (currentDistance < 0.8f && previousDistance >= 0.8f)
                {
                    //Event 
                    obstacleDetectedEvent?.Invoke(this, new EventArgs());
                }
                previousDistance = currentDistance;

                Thread.Sleep(200);
            }
        }
    }
}
