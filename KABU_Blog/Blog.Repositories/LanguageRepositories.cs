using System.Data.Entity;
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
