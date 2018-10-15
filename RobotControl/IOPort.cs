#define USE_EXTERNAL_DLL

using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace RobotCtrl
{

    /// <summary>
    /// This class abstracts the access to the io memory of the robot.
    /// </summary>
	public static class IOPort
    {
#if USE_EXTERNAL_DLL
        private static MethodInfo writeMethod;
        private static MethodInfo readMethod;
        
        static IOPort()
        {
            try
            {
                Assembly a = Assembly.LoadFrom("RobotIO.dll");
                Type[] t = a.GetTypes();
                writeMethod = t[3].GetMethod("Write", BindingFlags.Public | BindingFlags.Static);
                readMethod = t[3].GetMethod("Read", BindingFlags.Public | BindingFlags.Static);
            }
            catch (IOException ex)
            {
                MessageBox.Show("RobotIO.dll nicht gefunden.\r\nIm aktuellen Projekt unter References das RobotIO Projekt hinzufügen!\r\n\r\n" + ex.Message,
                    "RobotIO.dll nicht gefunden!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Write a given byte to a specific memory location of the robot.
        /// </summary>
        /// <param name="port">the address of the port to write (16 bit)</param>
        /// <param name="data">the data to write</param>
        public static void Write(int port, int data)
        {
            writeMethod.Invoke(null, new object[] { port, data });
        }


        /// <summary>
        /// Read a byte from a given memory location of the robot.
        /// </summary>
        /// <param name="port">the address of the port to read (16 bit)</param>
        /// <returns>the data from the memory</returns>
        public static int Read(int port)
        {
            return (int)readMethod.Invoke(null, new object[] { port });
        }

#else

        /// <summary>
        /// Write a given byte to a specific memory location of the robot.
        /// </summary>
        /// <param name="port">the address of the port to write (16 bit)</param>
        /// <param name="data">the data to write</param>
        public static void Write(int port, int data)
        {
            WriteByte((ushort)port, (byte)data);
        }

        /// <summary>
        /// Liest ein Byte von einer Port-Adresse
        /// </summary>
        /// <param name="port">the address of the port to read (16 bit)</param>
        /// <returns>the data from the memory</returns>
        public static int Read(int port)
        {
            return ReadByte((ushort)port);
        }
        
        [DllImport("CEDDK.dll", EntryPoint = "WRITE_PORT_UCHAR", CharSet = CharSet.Auto)]
        private static extern void WriteByte(ushort Addr, byte Value);

        [DllImport("CEDDK.dll", EntryPoint = "READ_PORT_UCHAR", CharSet = CharSet.Auto)]
        private static extern byte ReadByte(ushort Addr);

#endif
    }
}

