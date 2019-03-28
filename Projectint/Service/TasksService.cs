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
    }
}
