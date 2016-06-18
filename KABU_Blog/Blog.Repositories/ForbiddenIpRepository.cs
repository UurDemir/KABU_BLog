using System.Data.Entity;
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
