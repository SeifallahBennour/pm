using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplication1.Models.Entities;

namespace WebApplication1.Models
{
    public class CustomerRegisterDoctor : RegisterViewModel
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


    
                                           // public string ville { get; set; }
        public string Role { get; set; }
        [ForeignKey("SpecialityId")]
        public virtual Speciality specialite { get; set; }

        public int? SpecialityId { get; set; }
        [ForeignKey("VilleId")]
        public virtual VilleModel villes { get; set; }

        public int? VilleId { get; set; }
        public string PhoneNumber { get; set; }
        [DisplayName("Image")]
        public string imagePath { get; set; }
       
    }
}