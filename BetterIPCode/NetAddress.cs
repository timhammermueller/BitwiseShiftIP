using System;
using System.Collections.Generic;
using System.Text;

namespace BitwiseShiftIP
{
    public struct NetAddress
    {
        internal readonly int address;

        public NetAddress(byte segment1, byte segment2, byte segment3, byte segment4)
        {
            address = (segment1 << 24) | (segment2 << 16) | (segment3 << 8) | segment4;
        }
        public NetAddress(int address)
        {
            this.address = address;
        }

        public override string ToString()
        {
            return $"{GetIPSegment(3)}.{GetIPSegment(2)}.{GetIPSegment(1)}.{GetIPSegment(0)}";
        }

        byte GetIPSegment(int segmentIndex)
        {
            var bitOffset = segmentIndex * 8;
            return (byte)((address & (255 << bitOffset)) >> bitOffset);
        }

        public NetAddress CalculateNetworkAddress(int networkSize)
        {
            var netMask = int.MaxValue;
            netMask = netMask << (32 - networkSize);
            return new NetAddress(address & netMask);
        }
        public NetAddress CalculateNetworkAddress(SubnetMask subnetMask)
        {
            var netMask = int.MaxValue;
            netMask = netMask << (subnetMask.subnetSize);
            return new NetAddress(address & netMask);
        }

        public NetAddress CalculateBroadcastAddress(SubnetMask subnetMask)
        {
            var broadcastBits = ~(int.MaxValue << (subnetMask.subnetSize));
            return new NetAddress(address | broadcastBits);
        }

        public static NetAddress operator +(NetAddress a, int add) => new NetAddress(a.address + add);
        public static NetAddress operator -(NetAddress a, int sub) => new NetAddress(a.address - sub);



        //easter egg
        public static NetAddress operator *(NetAddress a, NetAddress b) => new NetAddress(a.address * b.address);

    }
}
