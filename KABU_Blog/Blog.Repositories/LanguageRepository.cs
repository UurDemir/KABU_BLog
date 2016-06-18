using System.Data.Entity;
using Blog.Models;
using Blog.Repositories.Commons;

namespace Blog.Repositories
{
  public  class LanguageRepository:GenericRepository<Language>,ILanguageRepository
    {
        public LanguageRepository(DbContext context) : base(context)
        {
        }
    }
}
