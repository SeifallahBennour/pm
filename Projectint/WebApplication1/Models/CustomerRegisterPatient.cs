using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CustomerRegisterPatient : RegisterViewModel
    {
        [Required]
        public int cin { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string Address { get; set; }
        //public string ville { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }


    }
}