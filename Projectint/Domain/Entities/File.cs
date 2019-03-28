using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class File
    {
        public int fileId { get; set; }
        public String filetitre { get; set; }
        [DataType(DataType.MultilineText)]
        public String content { get; set; }

    }
}
