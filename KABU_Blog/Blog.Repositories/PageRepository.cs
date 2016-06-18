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
    public class PageRepository : GenericRepository<Page>, IPageRepository
    {
        public PageRepository(DbContext context) : base(context)
        {
                
        }
    }
}
