using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class email
    {
        public int emailId { get; set; }

        public virtual User user1 { get; set; }

        public int? user1id { get; set; }

        public virtual User user2 { get; set; }
        public int? user2Id { get; set; }

        public String Sujet { get; set; }

        public String Corps { get; set; }
    }
}
