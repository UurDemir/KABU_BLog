using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Services.Commons;

namespace Blog.Services
{
    public interface ICommentService:IEntityService<Comment>
    {
        Task<Comment> FindById(int id, params Expression<Func<Comment, object>>[] includes);
    }
}
