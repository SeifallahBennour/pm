using Epione.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private Context datacontext;
        private IDataBaseFactory factory;
        public UnitOfWork(IDataBaseFactory factory)
        {
            this.factory = factory;
            this.datacontext = factory.DataContext;
        }
        public void Commit()
        {
            datacontext.SaveChanges();
        }

        public void Dispose()
        {
            factory.Dispose();
        }

        public IRepositoryBase<T> GetRepository<T>() where T : class
        {
            return new RepositoryBase<T>(factory);


        }
    }
}
