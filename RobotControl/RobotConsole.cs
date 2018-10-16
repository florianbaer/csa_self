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
                leds[i] = new Led(digitalOut, (LEDPin)i);
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
        /// Get the LEDPin of a given index.
        /// </summary>
        /// <param name="ledPin">the enum value of the LEDPin to return</param>
        /// <returns>the LEDPin object</returns>
        public Led this[LEDPin ledPin]
        {
            get { return this.leds[(int)ledPin]; }
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
