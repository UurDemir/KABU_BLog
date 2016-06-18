using System.Data.Entity;
using Blog.Models;
using Blog.Repositories.Commons;

namespace Blog.Repositories
{
    public class ArticleInfoRepository:GenericRepository<ArticleInfo>, IArticleInfoRepository
    {
        public ArticleInfoRepository(DbContext context) : base(context)
        {
        }
    }
}
