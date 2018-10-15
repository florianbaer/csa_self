using System;

namespace RobotCtrl
{

    /// <summary>
    /// EventArgs data object used by the <see cref="Switch"/>
    /// </summary>
    public class SwitchEventArgs : EventArgs
    {
        /// <summary>
        /// Initialise the event args.
        /// </summary>
        /// <param name="swi">the switch that got changed</param>
        /// <param name="switchEnabled">the current state of the switch</param>
        public SwitchEventArgs(Switches swi, bool switchEnabled)
        {
            Swi = swi;
            SwitchEnabled = switchEnabled;
        }
        
        /// <summary>
        /// The state of the switch (true = on, false = off).
        /// </summary>
        public bool SwitchEnabled { get; set; }


        /// <summary>
        /// The switch of the event.
        /// </summary>
        public Switches Swi { get; set; }
    }
}