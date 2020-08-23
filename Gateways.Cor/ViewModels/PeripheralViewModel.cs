using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gateways.Core.ViewModels
{
    public class PeripheralViewModel
    {
        public long Id { get; set; }
        [Required]
        [Display(Name = "UID")]
        public int Uid { get; set; }
        [Required]
        [Display(Name = "Vendor")]
        public string Vendor { get; set; }

        [Display(Name = "Created Date")]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        public DateTime CreatedDate { get; set; }
        [Required]
        [Display(Name = "Status")]
        public bool Status { get; set; }
        [Required]
        [Display(Name = "Gateway")]
        public long GatewayId { get; set; }

    }
}
