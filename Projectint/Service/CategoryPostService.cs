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
    public class CategoryPostService : Service<CategoryPost>, ICategoryPostService
    {
        private static IDataBaseFactory databaseFactory = new DataBaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);
        public CategoryPostService() : base(unit)
        {

        }
    }
}
