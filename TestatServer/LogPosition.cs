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
        private const string FileUrl = @"\Temp\log.csv";
        private const string FileHeader = "Team Bär/Foster";
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
            if(!File.Exists(FileUrl))
            {
                CreateFile();
            }

            string text = "";

            using (StreamReader sr = new StreamReader(FileUrl))
            {
                text = sr.ReadToEnd();
            }

            text += Environment.NewLine + DateTime.Now.ToString("dd/MM/yyyy-hh:mm:ss.fff") + ";" + x + ";" + y;

            using (StreamWriter writer = new StreamWriter(FileUrl))
            {
                writer.Write(text);
            }
        }

        public void CreateFile()
        {
            FileStream fs = File.Create(FileUrl);
            fs.Close();

            using (StreamWriter writer = new StreamWriter(FileUrl))
            {
                writer.Write(FileHeader);
            }
        }
    }
}
