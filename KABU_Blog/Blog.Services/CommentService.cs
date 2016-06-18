using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Repositories.Commons;
using Blog.Services.Commons;
using Blog.Services.UnitOfWork;

namespace Blog.Services
{
    public class CommentService : EntityService<Comment>, ICommentService
    {
        public CommentService(IUnitOfWork unitOfWork, IGenericRepository<Comment> repository) : base(unitOfWork, repository)
        {
        }

        public Task<Comment> FindById<TProperty>(int id, params Expression<Func<Comment, TProperty>>[] includes)
        {
            return FindBy(x => x.Id == id, includes);
        }
    }
}
