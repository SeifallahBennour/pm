using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Patient:User 
    {

        public virtual ICollection<Appointment> Appointment { get; set; }
        public virtual ICollection<Chat> Chat { get; set; }

    }
}
