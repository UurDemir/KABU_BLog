using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Repositories.Commons;

namespace Blog.Repositories
{
    public class ForbiddenIpRepository : GenericRepository<ForbiddenIp>, IForbiddenIpRepository
    {
        public ForbiddenIpRepository(DbContext context) : base(context)
        {

        }
    }
}
