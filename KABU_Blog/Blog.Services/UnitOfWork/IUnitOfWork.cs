using System.Threading.Tasks;

namespace Blog.Services.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> Commit();
    }
}