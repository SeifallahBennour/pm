using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class FileViewModel
    {
        public int fileId { get; set; }
        public String filetitre { get; set; }

        public String content { get; set; }


        // public virtual Member Member { get; set; }
        //public int Member_Id { get; set; }

    }
}