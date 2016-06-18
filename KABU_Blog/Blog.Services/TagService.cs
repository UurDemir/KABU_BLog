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
    class TagService : EntityService<Tag>, ITagService
    {
        public TagService(IUnitOfWork unitOfWork, IGenericRepository<Tag> repository) : base(unitOfWork, repository)
        {
        }

        public Task<Tag> FindById(int id, params Expression<Func<Tag, object>>[] includes)
        {
            return FindBy(x => x.Id == id, includes);
        }
    }
}
