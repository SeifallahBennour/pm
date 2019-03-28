using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models.Entities
{
    public class InfoRDV
    {
        public DateTime dateDisponobilite { get; set; }
        public int Iddoctor { get; set; }
        public int IdPatient { get; set; }

        public string message { get; set; }
        public int startHour { get; set; }
        public int endHour { get; set; }
        public string Description { get; set; }
    }
}
