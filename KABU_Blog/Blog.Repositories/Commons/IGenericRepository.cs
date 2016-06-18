using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Models.Commons;

namespace Blog.Repositories.Commons
{
    public interface IGenericRepository<T>
    {
        Task<IQueryable<T>> Get(params Expression<Func<T, object>>[] includes);
        Task<IQueryable<T>> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        T Add(T entity);
        T Delete(T entity);
        T Update(T entity);
        Task<int> Save();
    }
}