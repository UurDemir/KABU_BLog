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
    class LanguageRepositories:GenericRepository<Language>,ILanguageRepositories
    {
        public LanguageRepositories(DbContext context) : base(context)
        {
        }
    }
}
