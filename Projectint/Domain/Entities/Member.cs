using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Member :User
    {
        public virtual ICollection<History> listhistory { get; set; }

        public virtual ICollection<File> listfile { get; set; }

        public virtual ICollection<Tasks> listtasks { get; set; }

        public virtual ICollection<email> listmail { get; set; }




    }
}
