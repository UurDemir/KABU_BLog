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
    public class ArticleInfoService : EntityService<ArticleInfo>, IArticleInfoService
    {
        public ArticleInfoService(IUnitOfWork unitOfWork, IGenericRepository<ArticleInfo> repository) : base(unitOfWork, repository)
        {
        }


        public Task<ArticleInfo> FindById(int id, params Expression<Func<ArticleInfo, object>>[] includes)
        {
            return FindBy(x => x.Id == id, includes);
        }
    }
}
