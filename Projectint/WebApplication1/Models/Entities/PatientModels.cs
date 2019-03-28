using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models.Entities
{
    public class PatientModels : User 
    {
      
        public virtual ICollection<AppointmentModels> Appointment { get; set; }
        public virtual ICollection<Chat> Chat { get; set; }

    }
}
