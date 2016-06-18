
using System.Data.Entity;
using Blog.Models;
using Blog.Repositories.Commons;

namespace Blog.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext context) : base(context)
        {
        }

    }
}
