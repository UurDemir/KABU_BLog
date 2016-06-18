using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Services.Commons;

namespace Blog.Services
{
    public interface IPageService:IEntityService<Page>
    {

        Task<Page> FindById<TProperty>(int id, params Expression<Func<Page, TProperty>>[] includes);
    }
}