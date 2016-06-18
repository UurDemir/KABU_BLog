using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Models.Commons;

namespace Blog.Repositories.Commons
{
    public interface IGenericRepository<T>
    {
        Task<IQueryable<T>> Get<TProperty>(Expression<Func<T, bool>> predicate, params Expression<Func<T, TProperty>>[] includes);
        Task<T> FindBy<TProperty>(Expression<Func<T, bool>> predicate, params Expression<Func<T, TProperty>>[] includes);
        T Add(T entity);
        T Delete(T entity);
        T Update(T entity);
        Task<int> Save();
    }
}