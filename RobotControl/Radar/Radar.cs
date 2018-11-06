//------------------------------------------------------------------------------
// C #   I N   A C T I O N   ( C S A )
//------------------------------------------------------------------------------
// Repository:
//    $Id: Radar.cs 1039 2016-10-25 11:56:45Z chj-hslu $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public class Radar
    {
        private int ioAddress;

        public Radar(int IOAddress)
		{
            ioAddress = IOAddress;
        }

        /// <summary>
        /// Liefert die gemessene Distanz zum nächsten Objekt [m]
        /// </summary>
        public float Distance { get { return IOPort.Read(ioAddress) / 100.0f; } }
    }
}
