using RobotCtrl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace TestatServer
{
    public class LogPosition
    {
        private const string FileUrl = "C:\\temp\\log.csv";
        private const string FileHeader = "Team Bär/Foster";
        private Robot robot;

        public LogPosition(Robot robot)
        {
            this.robot = robot;
        }

        public void Start()
        {
            File.Create(FileUrl);

            using (StreamWriter writer = new StreamWriter(FileUrl))
            {
                writer.WriteLine(FileHeader);
            }

            while (!robot.Drive.Done)
            {
                PositionInfo position = this.robot.Position;
                writePosition(position.X, position.Y);

                Thread.Sleep(200);
            }
        }

        private void writePosition(float x, float y)
        {
            using (StreamWriter writer = new StreamWriter(FileUrl))
            {
                writer.WriteLine(DateTime.Now.ToString("dd/MM/yyyy-hh:mm:ss.fff") + ";" + x + ";" + y);
            }
        }
    }
}
