//------------------------------------------------------------------------------
// C #   I N   A C T I O N   ( C S A )
//------------------------------------------------------------------------------
// Repository:
//    $Id: Robot.cs 1039 2016-10-25 11:56:45Z chj-hslu $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public class Robot: IDisposable
    {

        #region members
        private RobotConsole robotConsole;
        private Radar radar;
        #endregion


        #region constructor & destructor
        public Robot()
        {
            this.robotConsole = new RobotConsole();
            this.radar = new Radar(Constants.IORadarSensor);
            Drive = new Drive();
        }

        /// <summary>
        /// Disposed das Drive-Objekt sowie die robotConsole.
        /// Damit werden die Worker-Threads in diesen Objekten beendet
        /// </summary>
        public void Dispose()
        {
            Drive.Dispose();
            this.robotConsole.Dispose();
        }
        #endregion


        #region properties
        /// <summary>
        /// Liefert die Konsole des Roboters
        /// </summary>
        public RobotConsole RobotConsole
        {
            get { return this.robotConsole; }
        }
        

        /// <summary>
        /// Liefert den Radar des Roboters
        /// </summary>
        public Radar Radar
        {
            get { return this.radar; }
        }


        /// <summary>
        /// Liefert den Antrieb des Roboters
        /// </summary>
        public Drive Drive
        {
            get;
            private set;
        }


        /// <summary>
        /// Liefert bzw. setzt die aktuelle Postion des Roboters.
        /// </summary>
        public PositionInfo Position { get { return Drive.Position; } set { Drive.Position = value; } }
        #endregion
    }
}
