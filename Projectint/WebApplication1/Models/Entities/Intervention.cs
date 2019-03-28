using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApplication1.Models.Entities
{
    public class Intervention
    {
        [Key]
        public int interventionId { get; set; }
        [Required]
        [Display(Name = "Description")]

        public string Description { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor doctor { get; set; }

        public int? DoctorId { get; set; }

    }
}
