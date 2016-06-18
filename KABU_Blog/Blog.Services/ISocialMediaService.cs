using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Services.Commons;

namespace Blog.Services
{
    public interface ISocialMediaService:IEntityService<SocialMedia>
    {
        Task<SocialMedia> FindById(string id, params Expression<Func<SocialMedia, object>>[] includes);
    }
}