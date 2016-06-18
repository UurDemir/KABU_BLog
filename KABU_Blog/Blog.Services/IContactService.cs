using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Services.Commons;

namespace Blog.Services
{
    public interface IContactService: IEntityService<Contact>
    {
        Task<Contact> FindById<TProperty>(int id, params Expression<Func<Contact, TProperty>>[] includes);
    }
}