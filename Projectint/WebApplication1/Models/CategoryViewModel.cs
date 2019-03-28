using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Entities
{
    public class CategoryViewModel
    {
        public int categoryId { get; set; }
        public String categoryname { get; set; }
       // public ICollection<ProjectViewModel> projects { get; set; }
    }
}