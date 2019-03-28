using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models.Entities
{
    public class Doctor : User
    {
       

        [ForeignKey("SpecialityID")]
        public Models.Entities.Speciality specialite { get; set; }
        public Doctor mydoctor { get; set; }
        public int? SpecialityId { get; set; }
        public virtual ICollection<Intervention> listeIntervention { get; set; }
        public virtual ICollection<Availability> listeAvailability { get; set; }
        public virtual ICollection<AppointmentModels> Appointment { get; set; }
        public virtual ICollection<Chat> Chat { get; set; }
        public string imagePath { get; set; }


    }
}
