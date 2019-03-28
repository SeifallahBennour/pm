using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models.Entities
{
    public  class VilleModel
    {
        [Key]
        public int VilleId { get; set; }
        public string villeNom { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
