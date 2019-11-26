using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;

namespace Contracts.DAL.Base
{
    public interface IBaseUnitOfWork
    {
        IBaseRepository<TDALEntity> BaseRepository<TDALEntity, TDomainEntity>()
            where TDomainEntity : class, IDomainEntity, new()
            where TDALEntity : class, new();
        
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}