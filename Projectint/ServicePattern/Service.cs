using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServicePattern
{
    public abstract class Service<T> : IService<T> where T : class
    {
        IUnitOfWork utk;
        protected Service(IUnitOfWork utk)
        {
            this.utk = utk;
        }
        public void Add(T entity)
        {
            utk.GetRepository<T>().Add(entity);
        }

        public void Commit()
        {
            try
            {
                utk.Commit();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Delete(Expression<Func<T, bool>> Condition)
        {
            utk.GetRepository<T>().Delete(Condition);
        }

        public void Delete(T entity)
        {
            utk.GetRepository<T>().Delete(entity);
        }

        public void Dispose()
        {
            utk.Dispose();
        }

      
        public T Get(Expression<Func<T, bool>> Condition)
        {
            return utk.GetRepository<T>().Get(Condition);
        }

        public T GetById(string id)
        {
            return utk.GetRepository<T>().GetById(id);
        }

        public T GetById(int id)
        {
            return utk.GetRepository<T>().GetById(id);
        }
        public T GetByIdF(double id)
        {
            return utk.GetRepository<T>().GetByIdF(id);
        }

        

        public virtual IEnumerable<T> GetAll()
        {
            return utk.GetRepository<T>().GetAll();
            //return _repository.GetById(id);
            //  return utwk.getRepository<TEntity>().GetById(id);
        }
        public IEnumerable<T> GetMany(Expression<Func<T, bool>> Condition = null, Expression<Func<T, bool>> OrderBy = null)
        {
            return utk.GetRepository<T>().GetMany(Condition, OrderBy);
        }
        public List<T> GetMany2(Expression<Func<T, bool>> Condition = null, Expression<Func<T, bool>> OrderBy = null)
        {
            return utk.GetRepository<T>().GetMany(Condition, OrderBy).ToList();
        }
        public void Update(T entity)
        {
            utk.GetRepository<T>().Update(entity);
        }
    }
}
