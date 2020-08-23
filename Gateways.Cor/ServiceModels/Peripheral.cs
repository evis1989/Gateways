using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gateways.Core.ServiceModels
{
    public class Peripheral
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public int Uid { get; set; }
        [Required]
        public string Vendor { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        public bool Status { get; set; }
        public long GatewayId { get; set; }
    }
}
