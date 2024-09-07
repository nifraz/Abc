using ABC.CarTraders.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace ABC.CarTraders.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        private DbSet<TEntity> _entities;

        public Repository(DbContext context)
        {
            Context = context;
            _entities = Context.Set<TEntity>();
        }

        protected IQueryable<TEntity> GetQueryable()
        {
            return _entities.AsQueryable();
        }

        public IEnumerable<TEntity> GetAllCached()
        {
            return _entities.Local.ToList();
        }


        public Task<TEntity> GetAsync(params object[] keyValues)
        {
            return _entities.FindAsync(keyValues);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entities.Where(predicate).ToListAsync();
        }


        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }


        public Task<int> CountAll()
        {
            return _entities.CountAsync();
        }

        public Task<int> CountWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.CountAsync(predicate);
        }

    }
}
