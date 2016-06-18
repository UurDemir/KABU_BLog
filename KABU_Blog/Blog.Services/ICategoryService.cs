using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Services.Commons;

namespace Blog.Services
{
    public interface ICategoryService:IEntityService<Category>
    {
        Task<Category> FindById(int id, params Expression<Func<Category, object>>[] includes);
    }
}