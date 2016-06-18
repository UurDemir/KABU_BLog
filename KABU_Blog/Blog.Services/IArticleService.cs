using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Services.Commons;

namespace Blog.Services
{
    public interface IArticleService : IEntityService<Article>
    {
        Task<Article> FindById<TProperty>(int id, params Expression<Func<Article, TProperty>>[] includes);
    }
}
