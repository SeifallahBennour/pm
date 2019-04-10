using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.Entities;

namespace WebApplication1.Models
{
    public class BlogViewModel
    {
        public int blogId { get; set; }
        public String titreblog { get; set; }
        public String contenu { get; set; }
        public String imagePath { get; set; }

        public DateTime dateblog { get; set; }


        public User userblog { get; set; }
        public int? userblogId { get; set; }

        public String username { get; set; }
    }
}