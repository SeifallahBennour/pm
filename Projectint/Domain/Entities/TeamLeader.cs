using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class TeamLeader :User
    {
        public String matricule { get; set; }
        public virtual ICollection<History> listhistory { get; set; }





        public virtual ICollection<email> listmail { get; set; }



    }
}
