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
    public class LanguageService:EntityService<Language>, ILanguageService
    {
        public LanguageService(IUnitOfWork unitOfWork, IGenericRepository<Language> repository) : base(unitOfWork, repository)
        {
        }

        public Task<Language> FindById(string id, params Expression<Func<Language, object>>[] includes)
        {
            return FindBy(x => x.Id == id, includes);
        }
    }
}
