using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Sender
    {
        [MaxLength(50)]
        public string? Name { get; set; }
        [MaxLength(50)]
        public string? Message { get; set; }
    }
}