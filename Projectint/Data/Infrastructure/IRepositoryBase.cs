using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);
        T GetById(long id);
        T GetByIdF(double id);
        T GetById(string id);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> condition);
        void Update(T entity);

        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> condition);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> 
            condition = null, Expression<Func<T, bool>> orderBy= null);

    }
}
