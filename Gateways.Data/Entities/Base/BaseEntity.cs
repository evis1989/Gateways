using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gateways.Data.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        public int? Id { get; set; }
    }
}
