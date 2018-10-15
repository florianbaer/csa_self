using System;
using System.Threading;
using RobotControl;

namespace RobotCtrl
{
    /// <summary>
    /// Input class to talk with all 4 Switches of the robot.
    /// </summary>
    public class DigitalIn : IDisposable
    {
        private Thread thread;
        private bool disposed;
        private bool run;
        public event EventHandler DigitalInChanged;


        /// <summary>
        /// Initialise the input for a IO port of the robot.
        /// </summary>
        /// <param name="port">IO-Port of the robot that is used to read the bits</param>
        public DigitalIn(int port)
        {
            Port = port;
            disposed = false;

            this.thread = new Thread(Run);
            this.thread.IsBackground = true;
            this.thread.Start();
        }


        /// <summary>
        /// Stop the background pulling thread on disposal.
        /// </summary>
        public void Dispose()
        {
            if (!disposed)
            {
                run = false;
                thread.Join();
                disposed = true;
            }
        }
        
        /// <summary>
        /// Get the IO-Port of the robot to access the input bits.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Get the data from the IO-Port.
        /// </summary>
        public int Data
        {
            get
            {
                return IOPort.Read(Port);
            }
        }
        
        /// <summary>
        /// Create the DigitalInChanged event.
        /// </summary>
        /// <param name="e">event parameters</param>
        protected void OnDigitalInChanged(EventArgs e)
        {
            if (DigitalInChanged != null)
            {
                DigitalInChanged(this, e);
            }
        }


        /// <summary>
        /// Access a single bit of the input.
        /// </summary>
        /// <param name="bit">index of the bit to access [0..3]</param>
        /// <returns>TRUE if the bit is 1, FALSE if the bit is 0</returns>
        public virtual bool this[int bit]
        {
            get
            {
                return RobotHelper.GetBitFromInteger(this.Data, bit);
            }
        }

        /// <summary>
        /// Run method of the background pulling thread to check the input port of the
        /// robot. The robot does not support interrupts (-.-), so a stupid polling is needed.
        /// </summary>
        private void Run()
        {
            int oldData = -1;
            int newData;
            run = true;
            while (run)
            {
                newData = this.Data;
                if (oldData != newData)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        bool oldBit = RobotHelper.GetBitFromInteger(oldData, i);
                        bool newBit = RobotHelper.GetBitFromInteger(newData, i);
                        if (oldBit != newBit)
                        {
                            this.OnDigitalInChanged(new SwitchEventArgs((Switches)i, newBit));
                        }
                    }
                }

                oldData = newData;
                Thread.Sleep(50);
            }
        }
    }
}