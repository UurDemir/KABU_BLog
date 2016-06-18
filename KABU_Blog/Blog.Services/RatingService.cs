
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Repositories.Commons;
using Blog.Services.Commons;
using Blog.Services.UnitOfWork;

namespace Blog.Services
{
    class RatingService : EntityService<Rating>, IRatingService
    {
        public RatingService(IUnitOfWork unitOfWork, IGenericRepository<Rating> repository) : base(unitOfWork, repository)
        {
        }

        public Task<Rating> FindById(string id, params Expression<Func<Rating, object>>[] includes)
        {
            return FindBy(x => x.Id == id, includes);
        }
    }
}
