using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApplication1.Models.Entities
{
   // public enum State { Valid , Invalid , Cancelied }
   public  class AppointmentModels
    {

        [Key]
        public int appointmentId { get; set; }

     
        public String dateAppointmentJEE { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime datePriseRDV { get; set; }
        [Required]
        public string reason { get; set; }
        public string state { get; set; }
        public string message { get; set; }
        public int note { get; set; }

        public int HourAppointment { get; set; }
        public float price { get; set; }

        public virtual Raiting Raiting { get; set; }
        public virtual Path path { get; set; }
       

        public int IdPatient { get; set; }
        public virtual PatientModels Patient { get; set; }

        public virtual Doctor Doctor { get; set; }
      







    }
}
