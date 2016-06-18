
using System.Data.Entity;
using Blog.Models;
using Blog.Repositories.Commons;

namespace Blog.Repositories
{
    class ArticleChangeRepository : GenericRepository<ArticleChange>
    {
        public ArticleChangeRepository(DbContext context) : base(context)
        {
        }

    }
}
