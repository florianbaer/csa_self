using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotControl
{
    class RobotHelper
    {
        public static bool GetBitFromInteger(int number, int index)
        {
            BitArray bitArray = new BitArray(new byte[] { (byte)number });
            return bitArray.Get(index);
        }

        public static int SetBitOfInteger(int number, int index, bool bit)
        {
            BitArray bitArray = new BitArray(new byte[] { (byte)number });
            bitArray.Set(index, bit);

            // convert bitArray back to int
            int[] intArray = new int[1];
            bitArray.CopyTo(intArray, 0);
            return intArray[0];
        }
    }
}
