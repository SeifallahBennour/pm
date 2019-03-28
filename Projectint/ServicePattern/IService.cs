using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServicePattern
{
    public interface IService<T> : IDisposable
    where T : class
    {

        void Add(T entity);
        void Delete(T entity); // delete entity
        void Delete(Expression<Func<T, bool>> Condition); //delete many
        void Update(T entity);
        T Get(Expression<Func<T, bool>> Condition);
        T GetById(int id);
        T GetById(string id);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> Condition = null, Expression<Func<T, bool>> OrderBy = null); // search or select 

        void Commit();
        // void Dispose(); hidden in IDisposable


    }
}
