using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Raiting
    {
       // [ForeignKey("Appointment")]
        [Key]
        public int id { get; set; }

        [Range(1, 5, ErrorMessage = "La note doit étre entre 1 et 5 ")]
        public float rating { get; set; }
      
        public virtual Appointment Appointment { get; set; }


    }
}
