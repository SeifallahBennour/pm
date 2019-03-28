using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.Entities;

namespace WebApplication1.Models
{
    public enum stat { To_Do, In_Progress, Done }
    public class ProjectViewModel
    {
        public int projectId { get; set; }
       public virtual CategoryViewModel category { get; set; }
        public int categoryId { get; set; }
        public String projectname { get; set; }
        public String description { get; set; }
        public String plan { get; set; }
        public String goals { get; set; }
        public stat state { get; set; }
        public ICollection<TasksViewModel> ListTask { get; set; }

        public virtual Entities.User team_leader { get; set; }

        public virtual int? team_leaderId { get; set; }
        public virtual String teamleadername { get; set; }
    }
}