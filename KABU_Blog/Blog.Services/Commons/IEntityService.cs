using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Models.Commons;

namespace Blog.Services.Commons
{
    public interface IEntityService<T>:IService where T : BaseEntity
    {
        void Create(T entity);
        
        void Delete(T entity);
        
        void Update(T entity);
        
        Task<IQueryable<T>> Get<TProperty>(Expression<Func<T, bool>> predicate,params Expression<Func<T, TProperty>>[] includes);
        
        Task<T> FindBy<TProperty>(Expression<Func<T, bool>> predicate, params Expression<Func<T, TProperty>>[] includes);

    }
}