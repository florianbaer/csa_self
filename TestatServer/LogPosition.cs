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
        private Robot robot;

        public LogPosition(Robot robot)
        {
            this.robot = robot;
        }

        public void Start()
        {
            CreateFile();

            while (true)
            {
                PositionInfo position = this.robot.Position;
                WritePosition(position.X, position.Y);

                Thread.Sleep(200);
            }
        }

        private void WritePosition(float x, float y)
        {
            if(!File.Exists(FileConstants.LogFileUrl))
            {
                CreateFile();
            }

            string text = "";

            using (StreamReader sr = new StreamReader(FileConstants.LogFileUrl))
            {
                text = sr.ReadToEnd();
            }

            text += Environment.NewLine + DateTime.Now.ToString("dd/MM/yyyy-hh:mm:ss.fff") + ";" + x + ";" + y;

            using (StreamWriter writer = new StreamWriter(FileConstants.LogFileUrl))
            {
                writer.Write(text);
            }
        }

        public void CreateFile()
        {
            FileStream fs = File.Create(FileConstants.LogFileUrl);
            fs.Close();

            using (StreamWriter writer = new StreamWriter(FileConstants.LogFileUrl))
            {
                writer.Write(FileConstants.FileHeader);
            }
        }
    }
}
