using System.Threading.Tasks;

namespace Blog.Services.UnitOfWork
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}