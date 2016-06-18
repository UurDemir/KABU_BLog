using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Repositories.Commons;

namespace Blog.Repositories
{
    public class Rating : GenericRepository<Models.Rating>
    {
        public Rating(DbContext context) : base(context)
        {
        }
    }
}
