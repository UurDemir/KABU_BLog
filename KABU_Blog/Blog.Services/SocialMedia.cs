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
    public class SocialMediaService:EntityService<SocialMedia>,ISocialMediaService
    {
        public SocialMediaService(IUnitOfWork unitOfWork, IGenericRepository<SocialMedia> repository) : base(unitOfWork, repository)
        {
        }

        public Task<SocialMedia> FindById(string id, params Expression<Func<SocialMedia, object>>[] includes)
        {
            return FindBy(x => x.Id == id, includes);
        }
    }
}
