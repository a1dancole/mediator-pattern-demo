using System.Threading.Tasks;

namespace Demo.Core.Database
{
    public interface IRepository
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
