using System;
using System.Collections.Generic;
using System.Text;

namespace Gateways.Core.ServiceModels
{
    public class Gateway
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Human_Readable { get; set; }
        public string Ipv4 { get; set; }
        public ICollection<Peripheral> Peripherals { get; set; }
        public int TotalPeripherals { get; set; }
    }
}
