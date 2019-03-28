using Data.Infrastructure;
using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public  class ServicePatient :Service<Patient>, IservicePatient
    {
        private static IDataBaseFactory f = new DataBaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(f);
        IServiceUser serviceUser = null;

        public ServicePatient() : base(ut)
        {
            serviceUser = new ServiceUser();

        }
       

    
}
}
