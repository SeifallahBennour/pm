using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public  class Speciality
    {
        [Key]
        public int SpecialityId { get; set; }
        public string nom { get; set; }

        public virtual ICollection<Doctor> Docteurs { get; set; }
    }
}
