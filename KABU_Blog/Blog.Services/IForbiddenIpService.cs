using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Repositories.Commons;
using Blog.Services.Commons;

namespace Blog.Services
{
    public interface IForbiddenIpService : IEntityService<ForbiddenIp>
    {
        Task<ForbiddenIp> FindById(int id, params Expression<Func<ForbiddenIp, object>>[] includes);

    }
}
