using System;

namespace RobotCtrl
{

    public enum Switches
    {
        Switch1 = 0,
        Switch2 = 1,
        Switch3 = 2,
        Switch4 = 3
    }

    /// <summary>
    /// Represents a switch of the robot.
    /// </summary>
    public class Switch
    {
        private Switches swi;
        private DigitalIn digitalIn;
        private bool oldState;
        
        public event EventHandler<SwitchEventArgs> SwitchStateChanged;
        
        
        /// <summary>
        /// Initialise a switch.
        /// </summary>
        /// <param name="digitalIn">used DigitalIn object</param>
        /// <param name="swi">the switch to represent</param>
        public Switch(DigitalIn digitalIn, Switches swi)
        {
            this.digitalIn = digitalIn;
            this.swi = swi;
            this.oldState = false;
            this.digitalIn.DigitalInChanged += new EventHandler(DigitalInChanged);
        }
        
        /// <summary>
        /// Status of the switch (on/off).
        /// </summary>
        public bool SwitchEnabled
        {
            get { return this.digitalIn[(int)swi]; }
        }

        /// <summary>
        /// Eventhandler that get called if the switch get changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">event params</param>
        private void DigitalInChanged(object sender, EventArgs e)
        {
            bool newState = SwitchEnabled;
            if (oldState != newState)
            {
                OnSwitchStateChanged(new SwitchEventArgs(this.swi, newState));
                oldState = newState;
            }
        }


        /// <summary>
        /// Notify all event handlers that are registered for the switch changed event.
        /// </summary>
        public void OnSwitchStateChanged(SwitchEventArgs e)
        {
            if (SwitchStateChanged != null)
            {
                SwitchStateChanged(this, e);
            }
        }

    }
}