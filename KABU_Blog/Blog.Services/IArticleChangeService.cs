using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Services.Commons;

namespace Blog.Services
{
    public interface IArticleChangeService : IEntityService<ArticleChange>
    {
        Task<ArticleChange> FindById(int id, params Expression<Func<ArticleChange, object>>[] includes);
    }
}