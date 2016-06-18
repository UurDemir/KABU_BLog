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
        
    }
}
