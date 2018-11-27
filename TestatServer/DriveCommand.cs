using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TestatServer
{
    [XmlRoot("RobotCommand")]
    public class DriveCommand
    {
        private const string FileUrl = @"\Temp\track.txt";

        public static List<RobotCommand> ReadCommands()
        {
            CreateFileIfNotExists();

            List<RobotCommand> commands = new List<RobotCommand>();

            using (StreamReader reader = new StreamReader(FileUrl))
            {
                while(reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();

                    string[] param = line.Split(' ');

                    switch(param[0])
                    {
                        case "TrackLine":
                            {
                                float length = float.Parse(param[1]);
                                commands.Add(new TrackLineRunCommand(length));

                                break;
                            }
                        case "TrackTurnLeft":
                            {
                                int angle = int.Parse(param[1]);
                                commands.Add(new TrackTurnLeftCommand(angle));

                                break;
                            }
                        case "TrackTurnRight":
                            {
                                int angle = int.Parse(param[1]);
                                commands.Add(new TrackTurnRightCommand(angle));

                                break;
                            }
                        case "TrackArcLeft":
                            {
                                int angle = int.Parse(param[1]);
                                float radius = float.Parse(param[2]);
                                commands.Add(new TrackArcLeftCommand(angle, radius));

                                break;
                            }
                        case "TrackArcRight":
                            {
                                int angle = int.Parse(param[1]);
                                float radius = float.Parse(param[2]);
                                commands.Add(new TrackArcRightCommand(angle, radius));

                                break;
                            }
                    }
                }
            }

            return commands;
        }

        public static void AppendCommand(string command)
        {
            CreateFileIfNotExists();

            string text = "";

            using (StreamReader sr = new StreamReader(FileUrl))
            {
                text = sr.ReadToEnd();
            }

            if(!string.IsNullOrEmpty(text))
            {
                text += Environment.NewLine;
            }

            text += command;

            using (StreamWriter writer = new StreamWriter(FileUrl))
            {
                writer.Write(text);
            }                
        }

        public static void CreateFile()
        {
            FileStream fs = File.Create(FileUrl);
            fs.Close();
        }

        private static void CreateFileIfNotExists()
        {
            if (!File.Exists(FileUrl))
            {
                CreateFile();
            }
        }
    }
}
