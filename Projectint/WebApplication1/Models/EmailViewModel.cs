using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.Entities;

namespace WebApplication1.Models
{
    public class EmailViewModel
    {
        public int emailId { get; set; }

        public virtual User user1 { get; set; }

        public int? user1Id { get; set; }

        public virtual User user2 { get; set; }
        public int? user2Id { get; set; }

        public String Sujet { get; set; }

        public String Corps { get; set; }
    }
}