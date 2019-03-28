using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Entities
{
    public class Path 
    {   [Key]
        public int pathId { get; set; }
        public string comment { get; set; }
        public virtual ICollection<AppointmentModels> listeAppointment { get; set; }

    }
}
