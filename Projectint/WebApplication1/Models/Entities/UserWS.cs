using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Entities
{
    public class UserWS
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string role { get; set; }
        public string email { get; set; }
        public string passeword { get; set; } 
    }
}