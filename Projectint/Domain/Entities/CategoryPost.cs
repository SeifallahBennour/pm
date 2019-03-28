using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CategoryPost
    {
        public int categorypostId {get;set;}
        public String nom { get; set; }
        public virtual ICollection<Post> ListPost { get; set; }

        public virtual Manager Manager { get; set; }
        public virtual int ManagerId { get; set; }
    }
}
