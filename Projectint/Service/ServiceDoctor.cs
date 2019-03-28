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
    public class ServiceDoctor : Service<Doctor>, IServiceDoctor
    {
        private static IDataBaseFactory f = new DataBaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(f);

        public ServiceDoctor() : base(ut)
        {

        }
    }
}
