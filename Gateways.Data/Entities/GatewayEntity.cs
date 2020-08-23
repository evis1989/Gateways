using Gateways.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Gateways.Data.Entities
{
    [Table("Gateway")]
    public class GatewayEntity:BaseEntity
    {
        public string SerialNumber { get; set; }
        public string Human_Readable { get; set; }
        public string Ipv4 { get; set; }
        public virtual ICollection<PeripheralEntity> Peripherals { get; set; }
    }
}
