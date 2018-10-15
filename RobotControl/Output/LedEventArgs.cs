using System;

namespace RobotCtrl
{
    /// <summary>
    /// EventArgs data object used by the <see cref="Led"/>
    /// </summary>
    public class LedEventArgs : EventArgs
    {
        /// <summary>
        /// Initialise the LedEventArgs.
        /// </summary>
        /// <param name="led">the LED that got changed</param>
        /// <param name="ledEnabled">state of the LED</param>
        public LedEventArgs(Leds led, bool ledEnabled)
        {
            Led = led;
            LedEnabled = ledEnabled;
        }
        
        /// <summary>
        /// The state of the LED (on/off).
        /// </summary>
        public bool LedEnabled { get; set; }

        /// <summary>
        /// The LED of the event.
        /// </summary>
        public Leds Led { get; set; }

    }
}