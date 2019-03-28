using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models.Entities
{
    public class allahmed
    {
        public Doctor mydoctor { get; set; }
        public Intervention myintervention { get; set; }

        public List<Intervention> interventionList { get; set; }


    }
}
