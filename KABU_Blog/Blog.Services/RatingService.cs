
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

        public Task<Rating> FindById<TProperty>(string id, params Expression<Func<Rating, TProperty>>[] includes)
        {
            return FindBy(x => x.Id == id, includes);
        }
    }
}
