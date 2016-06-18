using System.Data.Entity;
using Blog.Models;
using Blog.Repositories.Commons;

namespace Blog.Repositories
{
    public class RatingRepository : GenericRepository<Rating>,IRatingRepository
    {
        public RatingRepository(DbContext context) : base(context)
        {
        }
    }
}
