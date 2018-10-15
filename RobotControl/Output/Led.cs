using System;

namespace RobotCtrl
{

    public enum Leds
    {
        Led1 = 0,
        Led2,
        Led3,
        Led4
    }


    /// <summary>
    /// Represents an LED of the robot.
    /// </summary>
    public class Led
    {
        private Leds led;
        private DigitalOut digitalOut;
        private bool oldState;

        public event EventHandler<LedEventArgs> LedStateChanged;
        
        /// <summary>
        /// Initialise a new LED
        /// </summary>
        /// <param name="digitalOut">Used digitalOut object</param>
        /// <param name="led">the LED to control</param>
        public Led(DigitalOut digitalOut, Leds led)
        {
            this.digitalOut = digitalOut;
            this.led = led;
            this.oldState = false;
            this.digitalOut.DigitalOutputChanged += new EventHandler(DigitalOutputChanged);
        }

        /// <summary>
        /// Current state of the LED (on/off)
        /// </summary>
        public bool LedEnabled
        {
            get { return this.digitalOut[(int)led]; }
            set { this.digitalOut[(int)led] = value; }
        }

        /// <summary>
        /// Event to notify the change of the LED state.
        /// </summary>
        /// 
        /// <param name="sender">DigitalOut</param>
        /// <param name="e">event args</param>
        private void DigitalOutputChanged(object sender, EventArgs e)
        {
            bool newState = this.digitalOut[(int)led];
            if (oldState != newState)
            {
                OnLedStateChanged(new LedEventArgs(this.led, newState));
                oldState = newState;
            }
        }


        /// <summary>
        /// Notify all event handlers that the LED state has changed.
        /// </summary>
        public void OnLedStateChanged(LedEventArgs e)
        {
            if (LedStateChanged != null)
            {
                LedStateChanged(this, e);
            }
        }

    }
}