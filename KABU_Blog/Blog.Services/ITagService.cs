using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Services.Commons;

namespace Blog.Services
{
    public interface ITagService:IEntityService<Tag>
    {
        Task<Tag> FindById(int id, params Expression<Func<Tag, object>>[] includes);
    }
}