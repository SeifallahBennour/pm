using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class InfoRDV
    {
       
        public DateTime dateDisponobilite { get; set; }
        public int Id { get; set; }

        public int startHour { get; set; }
        public int endHour { get; set; }
        public string Description { get; set; }
    }
}
