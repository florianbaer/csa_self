namespace RobotIO
{
    public class IOPortEx
    {
        /// <summary>
        /// Writes a byte on a port address.
        /// </summary>
        /// <param name="port">The port address (16 Bit)</param>
        /// <param name="data">The byte to write</param>
        public static void Write(int port, int data)
        {
            GPIOPort.WritePort(port, data);
        }

        /// <summary>
        /// Reads a byte from a given port.
        /// </summary>
        /// <param name="port">The given port (16 Bit)</param>
        /// <returns>The read byte</returns>
        public static int Read(int port)
        {
            return GPIOPort.ReadPort(port);
        }
    }
}
