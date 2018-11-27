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
    public class CommandsXml
    {
        public Queue<RobotCommand> Commands { get; set; }
        private const string XmlUrl = "C:\\temp\\track.xml";

        public CommandsXml()
        {
            Commands = new Queue<RobotCommand>();
        }

        public static CommandsXml ReadXml()
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute
            {
                ElementName = "RobotCommand",
                IsNullable = true
            };

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CommandsXml), xmlRoot);

            using (XmlReader xmlReader = XmlReader.Create(XmlUrl))
            {
                CommandsXml newInstance = (CommandsXml)xmlSerializer.Deserialize(xmlReader);

                return newInstance;
            }
        }

        public static void WriteXml(object value)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CommandsXml));
            StringWriter stringWriter = new StringWriter();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings);

            xmlSerializer.Serialize(xmlWriter, value);
            string xml = stringWriter.ToString();

            FileStream fs = File.OpenWrite(XmlUrl);

            byte[] buffer = Encoding.UTF8.GetBytes(xml);
            fs.Write(buffer, 0, buffer.Length);
        }
    }
}
