using System;

namespace RobotCtrl
{
    /// <summary>
    /// EventArgs data object used by the <see cref="LedPin"/>
    /// </summary>
    public class LedEventArgs : EventArgs
    {
        /// <summary>
        /// Initialize the LedEventArgs.
        /// </summary>
        /// <param name="ledPin">the LEDPin that got changed</param>
        /// <param name="ledEnabled">state of the LEDPin</param>
        public LedEventArgs(LEDPin ledPin, bool ledEnabled)
        {
            LedPin = ledPin;
            LedEnabled = ledEnabled;
        }
        
        /// <summary>
        /// The state of the LEDPin (on/off).
        /// </summary>
        public bool LedEnabled { get; set; }

        /// <summary>
        /// The LEDPin of the event.
        /// </summary>
        public LEDPin LedPin { get; set; }

    }
}