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
    public class ProjectService : Service<Project>, IProjectService
    {

        private static IDataBaseFactory databaseFactory = new DataBaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);

        public ProjectService() : base(unit)
        {

        }
    }
}
