using System.Data.Entity;
using Blog.Models;
using Blog.Repositories.Commons;

namespace Blog.Repositories
{
   public  class ContactRepository:GenericRepository<Contact>, IContactRepository
    {
       public ContactRepository(DbContext context) : base(context)
       {
       }
        
    }
}
