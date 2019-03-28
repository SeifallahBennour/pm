using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Comment
    {
        public int commentId { get; set; }
        [DataType(DataType.MultilineText)]
        public String content { get; set; }
        public virtual Post pos { get; set; }
        public virtual int?  postId { get; set; }

      /*  public virtual User user { get; set; }
        public virtual int?  userId { get; set; }*/
    }
}
