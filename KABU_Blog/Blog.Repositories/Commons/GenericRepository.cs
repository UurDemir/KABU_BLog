using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Models.Commons;
using Blog.Models.Extensions;

namespace Blog.Repositories.Commons
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected DbContext Entities;
        protected readonly IDbSet<T> _dbSet;
        protected GenericRepository(DbContext context)
        {
            Entities = context;
            _dbSet = context.Set<T>();
        }

        public T Add(T entity)
        {
            Entities.Entry(entity).State = EntityState.Added;
            return _dbSet.Add(entity);
        }

        public T Delete(T entity)
        {
            return _dbSet.Remove(entity);
        }

        public Task<T> FindBy<TProperty>(Expression<Func<T, bool>> predicate, params Expression<Func<T, TProperty>>[] includes)
        {
            return _dbSet.IncludeRange(includes).FirstOrDefaultAsync(predicate);
        }

        public Task<IQueryable<T>> Get<TProperty>(Expression<Func<T, bool>> predicate, params Expression<Func<T, TProperty>>[] includes)
        {
            return Task.FromResult(_dbSet.Where(predicate).IncludeRange(includes));
        }

        public Task<int> Save()
        {
            return Entities.SaveChangesAsync();
        }

        public T Update(T entity)
        {
           Entities.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
