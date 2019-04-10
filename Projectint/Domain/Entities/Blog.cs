using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Blog
    {
        public int blogId { get; set; }
        public String titreblog { get; set; }
        public String contenu { get; set; }
        public String imagePath { get; set; }
        public DateTime dateblog { get; set; }
        [NotMapped]
        public String username { get; set; }

        public User userblog { get; set; }
        public int? userblogId { get; set; }
    }
}
