using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    
    public enum stat { To_Do,In_Progress,Done }
    public class Project
    {
        public int projectId { get; set; }
        public virtual Category category { get; set; }
        public int categoryId { get; set; }
        public String projectname { get; set; }
        public String description { get; set; }
        public String plan { get; set; }
        public String goals { get; set; }
        public stat state { get; set; }
        public virtual ICollection<Tasks> ListTask { get; set; }
        public virtual User team_leader { get; set; }

        public  int team_leaderId { get; set; }
    }
}
