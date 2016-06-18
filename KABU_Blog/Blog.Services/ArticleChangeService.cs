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
    public class ArticleChangeService : EntityService<ArticleChange>, IArticleChangeService
    {
        public ArticleChangeService(IUnitOfWork unitOfWork, IGenericRepository<ArticleChange> repository) : base(unitOfWork, repository)
        {
        }

        public Task<ArticleChange> FindById(int id, params Expression<Func<ArticleChange, object>>[] includes)
        {
            return FindBy(x => x.Id == id, includes);
        }
    }
}
