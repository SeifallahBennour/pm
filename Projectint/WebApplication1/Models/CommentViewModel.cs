using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.Entities;

namespace WebApplication1.Models
{
    public class CommentViewModel
    {
        public int commentId { get; set; }
        public String content { get; set; }

        public virtual PostViewModel pos { get; set; }
        public virtual int? postId { get; set; }

        //public virtual User user { get; set; }
        //public virtual int? userId { get; set; }
    }
}