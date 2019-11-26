using System.Threading.Tasks;

namespace Contracts.DAL.Base
{
    public interface IDataContext
    {
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}