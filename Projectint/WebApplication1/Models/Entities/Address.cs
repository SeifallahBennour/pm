using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models.Entities
{
    public struct  Address
    {
        [Required]
        public string street { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public int postalCode { get; set; }
        [Required]
        public string country { get; set; }
       
    }
}
