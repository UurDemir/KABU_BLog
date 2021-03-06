﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Models.Commons;
using Blog.Models.Extensions;
using Blog.Models.Types;

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
            Entities.Entry(entity).State = EntityState.Modified;
            entity.Status = Status.Deleted;
            return entity;
        }
        public T Update(T entity)
        {
            Entities.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public Task<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return _dbSet.IncludeRange(includes).FirstOrDefaultAsync(predicate);
        }

        public Task<IQueryable<T>> Get(params Expression<Func<T, object>>[] includes)
        {
            return Task.FromResult(_dbSet.IncludeRange(includes));
        }

        public Task<IQueryable<T>> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return Task.FromResult(_dbSet.Where(predicate).IncludeRange(includes));
        }

        public Task<int> Save()
        {
            return Entities.SaveChangesAsync();
        }

    }
}
