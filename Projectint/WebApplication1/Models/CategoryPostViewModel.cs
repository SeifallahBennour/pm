using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CategoryPostViewModel
    {
        public int categorypostId { get; set; }
        public String nom { get; set; }
        public virtual ICollection<PostViewModel> ListPost { get; set; }
    }
}