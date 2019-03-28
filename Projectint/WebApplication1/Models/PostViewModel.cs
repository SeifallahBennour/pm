using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PostViewModel
    {
        public int postId { get; set; }
        public String posttitre { get; set; }
        public String content { get; set; }

        public virtual ICollection<CommentViewModel> ListComment { get; set; }

        public virtual CategoryPostViewModel cat { get; set; }
        public virtual int? categoriepostId { get; set; }
        public virtual String categoriename { get; set; }

        public int post_like { get; set; }
    }
}