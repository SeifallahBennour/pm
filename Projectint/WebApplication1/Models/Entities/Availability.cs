using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models.Entities
{
    public class Availability
    {
        [Key]
        public int id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime dateDisponobilite { get; set; }
        public string dateAvailable { get; set; }

        public int startHour { get; set; }
        public int endHour { get; set; }
        public string Etat { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor doctor { get; set; }

        public int? DoctorId { get; set; }
    }
    }
