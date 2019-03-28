using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category
    {
        public int categoryId { get; set; }
        public String categoryname { get; set; }

        public ICollection<Project> ListProject { get; set; }
    }
}
