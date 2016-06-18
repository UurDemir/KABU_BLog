using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Services.Commons;

namespace Blog.Services
{
    public interface ISettingService : IEntityService<Setting>
    {
        Task<Setting> FindById(string id, params Expression<Func<Setting, object>>[] includes);
    }
}
