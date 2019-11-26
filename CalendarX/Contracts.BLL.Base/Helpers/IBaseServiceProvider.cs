using Contracts.BLL.Base.Services;
using Contracts.DAL.Base;

namespace Contracts.BLL.Base.Helpers
{
    public interface IBaseServiceProvider
    {
        TService GetService<TService>();
        //IBaseEntityService<TEntity> GetEntityService<TEntity>() where TEntity : class, IBaseEntity<int>, new();
    }
}