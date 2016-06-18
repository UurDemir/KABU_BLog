using System.Data.Entity;
using Blog.Models;
using Blog.Repositories.Commons;

namespace Blog.Repositories
{
    public class TagRepository :  GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(DbContext context) : base(context)
        {
            
        }
    }
}
