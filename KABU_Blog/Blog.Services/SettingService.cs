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
    public class SettingService : EntityService<Setting>, ISettingService
    {
        public SettingService(IUnitOfWork unitOfWork, IGenericRepository<Setting> repository) : base(unitOfWork, repository)
        {

        }


        public Task<Setting> FindById(string id, params Expression<Func<Setting, object>>[] includes)
        {
            return FindBy(x => x.Id == id, includes);
        }
    }
}
