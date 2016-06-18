using System.Data.Entity;
using Blog.Models;
using Blog.Repositories.Commons;

namespace Blog.Repositories
{
    public class ArticleInfoRepositories:GenericRepository<ArticleInfo>, IArticleInfoRepository
    {
        public ArticleInfoRepositories(DbContext context) : base(context)
        {
        }
    }
}
