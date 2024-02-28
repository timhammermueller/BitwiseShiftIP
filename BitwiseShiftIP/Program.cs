using System;
using System.Net;

namespace BitwiseShiftIP
{
    class Program
    {
        static void Main(string[] args)
        {
            var localAddress = new NetAddress(192, 168, 178, 1);
            var subnet = new SubnetMask(24);
            var networkAddress = localAddress.CalculateNetworkAddress(subnet);
            var firstHost = networkAddress + 1;
            var secondHost = networkAddress + 2;
            var lastHost = networkAddress + subnet.CalculateHostCount();
            var broadcast = networkAddress.CalculateBroadcastAddress(subnet);
        }
    }
}
