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

        Task<IQueryable<T>> Get( params Expression<Func<T, object>>[] includes);

        Task<IQueryable<T>> Get(Expression<Func<T, bool>> predicate,params Expression<Func<T, object>>[] includes);
        
        Task<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

    }
}