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

        public DriveCommand() { }

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

        public static void WriteCommand(string command)
        {
            CreateFileIfNotExists();

            using (StreamWriter writer = new StreamWriter(FileUrl))
            {
                writer.WriteLine(command);
            }                
        }

        private static void CreateFileIfNotExists()
        {
            if (!File.Exists(FileUrl))
            {
                FileStream fs = File.Create(FileUrl);

                fs.Close();
            }
        }
    }
}
