using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Repositories.Commons;

namespace Blog.Repositories
{
    public class TagRepository :  GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(DbContext context) : base(context)
        {
            
        }
    }
}
