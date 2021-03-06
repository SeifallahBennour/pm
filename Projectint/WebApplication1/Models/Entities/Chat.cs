﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models.Entities
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string sender { get; set; }
        [Required]
        public string receiver { get; set; }
        [Required]
        public string objectC { get; set; }
        public virtual PatientModels Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
