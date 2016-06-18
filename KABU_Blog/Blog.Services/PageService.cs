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
    public class PageService : EntityService<Page>, IPageService
    {
        public PageService(IUnitOfWork unitOfWork, IGenericRepository<Page> repository) : base(unitOfWork, repository)
        {

        }

        public Task<Page> FindById<TProperty>(int id, params Expression<Func<Page, TProperty>>[] includes)
        {
            return FindBy(x => x.Id = id, includes);
        }
    }
}
