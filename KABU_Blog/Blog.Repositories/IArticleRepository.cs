using Blog.Models;
using Blog.Repositories.Commons;

namespace Blog.Repositories
{
    public interface IArticleRepository : IGenericRepository<Article>
    {
    }
}
