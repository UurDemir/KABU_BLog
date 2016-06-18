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
    public class ContactService : EntityService<Contact>, IContactService
    {
        public ContactService(IUnitOfWork unitOfWork, IGenericRepository<Contact> repository) : base(unitOfWork, repository)
        {
        }

        public Task<Contact> FindById(int id, params Expression<Func<Contact, object>>[] includes)
        {
            return FindBy(x => x.Id == id, includes);
        }
    }
}
