using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ABC.CarTraders.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAllCached();

        Task<TEntity> GetAsync(params object[] keyValues);
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);

        //IEnumerable<TEntity> GetAllAdded();
        //IEnumerable<TEntity> GetAllModified();
        //IEnumerable<TEntity> GetAllDeleted();

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<TEntity, bool>> predicate);
    }
}
