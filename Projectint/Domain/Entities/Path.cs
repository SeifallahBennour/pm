using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Path 
    {   [Key]
        public int pathId { get; set; }
        public string comment { get; set; }
        public virtual ICollection<Appointment> listeAppointment { get; set; }

    }
}
