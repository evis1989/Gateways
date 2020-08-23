using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gateways.Core.ViewModels
{
    public class GatewayViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
        [Required]
        [Display(Name = "Name Human Readable ")]
        public string Human_Readable { get; set; }
        [Required]
        [Display(Name = "IPv4 address")]
        public string Ipv4 { get; set; }
        public IList<PeripheralViewModel> Peripherals { get; set; }
        [Required]
        [Display(Name = "Peripherals")]
        [Range(0, 10, ErrorMessage = "No more that 10 peripheral devices are allowed for a gateway.")]
        public int TotalPeripherals { get; set; }
    }
}
