//------------------------------------------------------------------------------
// C #   I N   A C T I O N   ( C S A )
//------------------------------------------------------------------------------
// Repository:
//    $Id: Robot.cs 828 2012-08-05 09:10:38Z zajost $
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
        private Drive drive;
        #endregion


        #region constructor & destructor
        public Robot()
        {

            this.robotConsole = new RobotConsole();
            this.drive = new Drive();
        }

        /// <summary>
        /// Disposed das Drive-Objekt sowie die robotConsole.
        /// Damit werden die Worker-Threads in diesen Objekten beendet
        /// </summary>
        public void Dispose()
        {
            this.drive.Dispose();
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
        /// Liefert den Antrieb des Roboters
        /// </summary>
        public Drive Drive
        {
            get { return this.drive; }
        }


        /// <summary>
        /// Liefert bzw. setzt die aktuelle Postion des Roboters.
        /// </summary>
        public PositionInfo Position { get { return drive.Position; } set { drive.Position = value; } }
        #endregion
    }
}
