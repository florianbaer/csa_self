using System;

namespace RobotCtrl
{

    public enum LEDPin
    {
        Led1 = 0,
        Led2,
        Led3,
        Led4
    }


    /// <summary>
    /// Represents a Led of the robot.
    /// </summary>
    public class Led
    {
        private LEDPin ledPin;
        private DigitalOut digitalOut;
        private bool oldState;

        public event EventHandler<LedEventArgs> LedStateChanged;
        
        /// <summary>
        /// Initialise a new LEDPin
        /// </summary>
        /// <param name="digitalOut">Used digitalOut object</param>
        /// <param name="ledPin">the LEDPin to control</param>
        public Led(DigitalOut digitalOut, LEDPin ledPin)
        {
            this.digitalOut = digitalOut;
            this.ledPin = ledPin;
            this.oldState = false;
            this.digitalOut.DigitalOutputChanged += DigitalOutputChanged;
        }

        /// <summary>
        /// Current state of the LEDPin (on/off)
        /// </summary>
        public bool LedEnabled
        {
            get { return this.digitalOut[(int)ledPin]; }
            set { this.digitalOut[(int)ledPin] = value; }
        }

        /// <summary>
        /// Event to notify the change of the LEDPin state.
        /// </summary>
        /// 
        /// <param name="sender">DigitalOut</param>
        /// <param name="e">event args</param>
        private void DigitalOutputChanged(object sender, EventArgs e)
        {
            bool newState = this.digitalOut[(int)ledPin];
            if (oldState != newState)
            {
                OnLedStateChanged(new LedEventArgs(this.ledPin, newState));
                oldState = newState;
            }
        }


        /// <summary>
        /// Notify all event handlers that the LEDPin state has changed.
        /// </summary>
        public void OnLedStateChanged(LedEventArgs ledEventArgs)
        {
            if (LedStateChanged != null)
            {
                LedStateChanged(this, ledEventArgs);
            }
        }

    }
}