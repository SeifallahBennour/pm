using Data.Infrastructure;
using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TasksService : Service<Tasks>, ITasksService
    {
        private static IDataBaseFactory databaseFactory = new DataBaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);
        public TasksService() : base(unit)
        {

        }

        public void AddTaskWS(Tasks tasks)
        {

            Tasks t = new Tasks();

            t.tasksId = tasks.tasksId;
            t.nomtask = tasks.nomtask;
            t.projectId = tasks.projectId;
            t.team_memberId = tasks.team_memberId;
            t.DifficulteId = tasks.DifficulteId;

            
            // p.datepost = DateTime.Now;

            Add(t);
            Commit();




        }
    }
}
