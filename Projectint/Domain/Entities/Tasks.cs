using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public class Tasks
    {
        public int tasksId { get; set; }
        //public DateTime deadline { get; set; }
        public int duration { get; set; }
        //public state state { get; set; }
        //[Required(ErrorMessage = "You have to choose a project")]

        public virtual Project proj { get; set; }
        [Required(ErrorMessage = "You have to choose a project")]
        public int projectId { get; set; } //on a l'ajouté
    }
}
