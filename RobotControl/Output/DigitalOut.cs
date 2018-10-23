using System;
using RobotControl;

namespace RobotCtrl
{

    /// <summary>
    /// Output class to talk to all LEDs of the robot.
    /// </summary>
    public class DigitalOut
    {
        private int data;
        public event EventHandler DigitalOutputChanged;
        
        /// <summary>
        /// Initialise the digital out and set the value to 0.
        /// </summary>
        /// <param name="port">the IO-Port of the robot</param>
        public DigitalOut(int port)
        {
            Port = port;
            data = 0;
        }
        
        /// <summary>
        /// The used IO-Port.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// The data of the LEDs. This property is used to set or read the LEDs all together.
        /// The rule is:
        ///  Bit 0 = LED1
        ///  Bit 1 = LED2
        ///  Bit 2 = LED3
        ///  Bit 3 = LED4
        /// </summary>
        public int Data
        {
            get { return data; }
            set 
            {
                int oldValue = this.data;
                this.data = value;
                IOPort.Write(Port, data);
                for (int i = 0; i < 4; i++)
                {
                    bool oldBit = RobotHelper.GetBitFromInteger(oldValue, i);
                    bool newBit = RobotHelper.GetBitFromInteger(value, i);
                    if (oldBit != newBit)
                    {
                        this.DigitalOutputChanged(this, new LedEventArgs((LEDPin)i, newBit));
                    }
                }
            }
        }
        
        /// <summary>
        /// Call the digital output changed event handlers.
        /// </summary>
        /// <param name="e">event args</param>
        protected void OnDigitalOutputChanged(EventArgs e)
        {
            if (DigitalOutputChanged != null)
            {
                DigitalOutputChanged(this, e);
            }
        }


        /// <summary>
        /// Access a single bit of the output.
        /// </summary>
        /// 
        /// <param name="bit">index of the bit to access [0..3]</param>
        /// <returns>TRUE if the bit is 1, FALSE if the bit is 0</returns>
        public virtual bool this[int bit]
        {
            get
            {
                return RobotHelper.GetBitFromInteger(data, bit);
            }
            set
            {
                this.Data = RobotHelper.SetBitOfInteger(data, bit, value);
            }
        }
    }
}