using System;
using System.Collections.Generic;
using System.Text;

namespace BitwiseShiftIP
{
    public class SubnetMask
    {
        internal int subnetSize;

        public int NetworkSize => 32 - subnetSize;
        public SubnetMask(int networkSize)
        {
            subnetSize = 32 - networkSize;
        }

        public int CalculateHostCount()
        {
            return (int)Math.Pow(2, subnetSize)-2;
        }
    }
}
