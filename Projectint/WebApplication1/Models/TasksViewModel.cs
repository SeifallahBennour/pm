using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public enum state { To_Do, In_Progress, Done }

    public class TasksViewModel
    {
        public int taskId { get; set; }
        //public DateTime deadline { get; set; }
        public int duration { get; set; }
        //public state state { get; set; }
       

        public virtual ProjectViewModel proj { get; set; }
        public int projectId { get; set; }
    }
}