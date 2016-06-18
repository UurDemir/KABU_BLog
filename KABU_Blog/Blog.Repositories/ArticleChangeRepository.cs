
using System.Data.Entity;
using Blog.Models;
using Blog.Repositories.Commons;

namespace Blog.Repositories
{
    public class ArticleChangeRepository : GenericRepository<ArticleChange>, IArticleChangeRepository
    {
        public ArticleChangeRepository(DbContext context) : base(context)
        {
        }

    }
}
