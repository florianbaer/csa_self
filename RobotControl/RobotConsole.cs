using System;

namespace RobotCtrl
{

    /// <summary>
    /// Represents the console of the robot, containing multiple LEDs and switches.
    /// </summary>
    public class RobotConsole : IDisposable
    {
        private Led[] leds;
        private Switch[] switches;
        private DigitalIn digitalIn;
        private DigitalOut digitalOut;
        
        /// <summary>
        /// Initialise the robot console with all LEDs/Switches.
        /// </summary>
        public RobotConsole()
        {
            digitalIn = new DigitalIn(Constants.IOConsoleSWITCH);
            digitalOut = new DigitalOut(Constants.IOConsoleLED);

            this.leds = new Led[4];
            for (int i = 0; i < this.leds.Length; i++)
            {
                leds[i] = new Led(digitalOut, (Leds)i);
            }

            this.switches = new Switch[4];
            for (int i = 0; i < this.switches.Length; i++)
            {
                switches[i] = new Switch(digitalIn, (Switches)i);
            }
        }

        public void Dispose()
        {
            digitalIn.Dispose();
            //digitalOut.Dispose();
        }

        /// <summary>
        /// Get the LED of a given index.
        /// </summary>
        /// <param name="led">the enum value of the LED to return</param>
        /// <returns>the LED object</returns>
        public Led this[Leds led]
        {
            get { return this.leds[(int)led]; }
        }

        /// <summary>
        /// Get the switch of a given index.
        /// </summary>
        /// <param name="swi">the enum value of the switch to return</param>
        /// <returns></returns>
        public Switch this[Switches swi]
        {
            get { return this.switches[(int)swi]; }
        }
    }
}
