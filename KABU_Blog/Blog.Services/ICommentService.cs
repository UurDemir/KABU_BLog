using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Services.Commons;

namespace Blog.Services
{
    public interface ICommentService : IEntityService<Comment>
    {
        Task<Comment> FindById<TProperty>(int id, params Expression<Func<Comment, TProperty>>[] includes);
    }
}