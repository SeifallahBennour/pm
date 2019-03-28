using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public  class RDV
    {
        public DateTime dateAppointment { get; set; }
        public DateTime datePriseRDV { get; set; }
        public string reason { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

       

                               
    }
}
