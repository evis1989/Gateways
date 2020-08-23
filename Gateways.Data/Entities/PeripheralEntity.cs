using Gateways.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Gateways.Data.Entities
{
    [Table("Peripheral")]
    public class PeripheralEntity : BaseEntity
    {
        public int Uid { get; set; }
        public string Vendor { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public virtual GatewayEntity GatewayEntity { get; set; }
    }
}
