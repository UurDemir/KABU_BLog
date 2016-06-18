using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Repositories.Commons;

namespace Blog.Repositories
{
    public interface IForbiddenIpRepository : IGenericRepository<ForbiddenIp>
    {
    }
}
