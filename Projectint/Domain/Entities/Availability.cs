using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{ 
    public class Availability
    {   [Key]
        public int id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime dateDisponobilite{ get; set; }
        public int idU { get; set; }
        public string dateAvailable { get; set; }

        
        public bool IsfullDay { get; set; }
        public int startHour { get; set; }
        public int endHour { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string Etat { get; set; }
        public string Description { get; set; }

        [ForeignKey("DoctorId")]
        public Doctor doctor { get; set; }
        public string Subject { get; set; }
        public string ThemeColor { get; set; }
        public DateTime Day { get; set; }


        public int? DoctorId { get; set; }
    }
}
