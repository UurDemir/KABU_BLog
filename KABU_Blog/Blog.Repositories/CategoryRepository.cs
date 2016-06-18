using System;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Repositories.Commons;

namespace Blog.Repositories
{
    public class CategoryRepository:GenericRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }

        public Task<Category> FindById<TProperty>(int id, params Expression<Func<Category, TProperty>>[] includes)
        {
            return FindBy(x => x.Id == id, includes);
        }
    }
}
