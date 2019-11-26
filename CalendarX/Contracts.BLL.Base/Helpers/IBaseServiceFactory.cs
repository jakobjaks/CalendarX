using System;
using Contracts.DAL.Base;

namespace Contracts.BLL.Base.Helpers
{
    public interface IBaseServiceFactory<TUnitOfWork>
        where TUnitOfWork : IBaseUnitOfWork
    {
        void AddToCreationMethods<TService>(Func<TUnitOfWork, TService> creationMethod)
            where TService : class;

        Func<TUnitOfWork, object> GetServiceFactory<TService>();

        /*
        // Too many generics needed, not doing it!
        Func<TUnitOfWork, object> GetEntityServiceFactory<TEntity>()
            where TEntity : class, IDomainEntity, new();
        */
    }
}