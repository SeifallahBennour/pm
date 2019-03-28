using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Intervention
    {
        [Key]
        public int interventionId { get; set; }
        [Required]
        public string Description { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor doctor { get; set; }

        public int? DoctorId { get; set; }
		 public int idU { get; set; }

        
    }
}
