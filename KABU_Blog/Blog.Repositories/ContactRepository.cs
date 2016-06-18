using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
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
