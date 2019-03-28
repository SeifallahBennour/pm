using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit(); // savechange
        IRepositoryBase<T> GetRepository<T>() where T : class;  //traja3 repository
    }
}
