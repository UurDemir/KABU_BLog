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
    public class ForbiddenIpService : EntityService<ForbiddenIp>, IForbiddenIpService
    {
        public ForbiddenIpService(IUnitOfWork unitOfWork, IGenericRepository<ForbiddenIp> repository) : base(unitOfWork, repository)
        {
                
        }

        public Task<ForbiddenIp> FindById<TProperty>(int id, params Expression<Func<ForbiddenIp, TProperty>>[] includes )
        {
            return FindBy(x => x.Id == id, includes);
        }
    }
}
