using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Services.Commons;

namespace Blog.Services
{
    public interface ITagService:IEntityService<Tag>
    {
        Task<Tag> FindById<TProperty>(int id, params Expression<Func<Tag, TProperty>>[] includes);
    }
}