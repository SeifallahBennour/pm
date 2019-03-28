using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Doctor:User
    {
       // public string specialite { get; set; }
      
        public virtual ICollection<Availability> listeAvailability { get; set; }
        public virtual ICollection<Appointment> Appointment { get; set; }
        public virtual ICollection<Chat> Chat { get; set; }

        [ForeignKey("SpecialityId")]
        public virtual Speciality specialite { get; set; }

        public int? SpecialityId { get; set; }

        public string imagePath { get; set; }


    }
}
