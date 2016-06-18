using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Repositories.Commons;

namespace Blog.Repositories
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Task<Category> FindById<TProperty>(int id, params Expression<Func<Category, TProperty>>[] includes);
    }
}