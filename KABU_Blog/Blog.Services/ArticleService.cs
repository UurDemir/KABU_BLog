using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Repositories.Commons;
using Blog.Services.Commons;
using Blog.Services.UnitOfWork;

namespace Blog.Services
{
    public class ArticleService : EntityService<Article>,IArticleService
    {
        public ArticleService(IUnitOfWork unitOfWork, IGenericRepository<Article> repository) : base(unitOfWork, repository)
        {

        }

        public Task<Article> FindById<TProperty>(int id, params Expression<Func<Article, TProperty>>[] includes)
        {
            return FindBy(x => x.Id == id, includes);
        }
    }
}
