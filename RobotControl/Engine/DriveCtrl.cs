//------------------------------------------------------------------------------
// C #   I N   A C T I O N   ( C S A )
//------------------------------------------------------------------------------
// Repository:
//    $Id: MotorCtrl.cs 973 2015-11-10 13:12:03Z zajost $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using RobotControl;

namespace RobotCtrl
{

    public class DriveCtrl : IDisposable
    {
        private int ioAddress;
        
        
        public DriveCtrl(int IOAddress)
        {
            this.ioAddress = IOAddress;
            Reset();
        }

        public void Dispose()
        {
            Reset();
        }

        
        /// <summary>
        /// Schaltet die Stromversorgung der beiden Motoren ein oder aus.
        /// </summary>
        public bool Power
        {
            set { DriveState = (value) ? DriveState | 0x03 : DriveState & ~0x03; }
        }


        /// <summary>
        /// Liefert den Status ob der rechte Motor ein-/ausgeschaltet ist bzw. schaltet den rechten Motor ein-/aus.
        /// Die Information dazu steht im Bit0 von DriveState.
        /// </summary>
        public bool PowerRight
        {
            get
            {
                return (this.DriveState & 0x01) != 0;
            }
            set { this.DriveState = value ? (this.DriveState | 0x01) : (this.DriveState & ~0x01); }
        }


        /// <summary>
        /// Liefert den Status ob der linke Motor ein-/ausgeschaltet ist bzw. schaltet den linken Motor ein-/aus.
        /// </summary>
        public bool PowerLeft
        {
            get { return (DriveState & 0x02) != 0; }
            set { DriveState = (value) ? DriveState | 0x02 : DriveState & ~0x02; }
        }


        /// <summary>
        /// Bietet Zugriff auf das Status-/Controlregister
        /// </summary>
        public int DriveState
        {
            get { return IOPort.Read(ioAddress); }
            protected set { IOPort.Write(ioAddress, value); }
        }

        /// <summary>
        /// Setzt die beiden Motorencontroller (LM629) zurück, 
        /// indem kurz die Reset-Leitung aktiviert wird.
        /// </summary>
        public void Reset()
        {
            this.DriveState = 0x00;
            Thread.Sleep(5);
            this.DriveState = 0x80;
            Thread.Sleep(5);
            this.DriveState = 0x00;
        }

    }
}
