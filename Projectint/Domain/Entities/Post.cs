using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Post
    {
        public int postId { get; set; }
        public String posttitre { get; set; }
        [DataType(DataType.MultilineText)]
        public String content { get; set; }
        public virtual ICollection<Comment> ListComment { get; set; }

        public virtual CategoryPost cat { get; set; }
        public virtual int? categorypostId { get; set; }

        public virtual User user { get; set; }
        public virtual int? userId { get; set; }

        public int post_like { get; set; }


    }
}
