using System;
using System.Collections.Generic;
using Contracts.BLL.Base.Helpers;
using Contracts.BLL.Base.Services;
using Contracts.DAL.Base;

namespace BLL.Base.Helpers
{
    public class BaseServiceProvider<TUnitOfWork> : IBaseServiceProvider
        where TUnitOfWork : IBaseUnitOfWork
    {
        protected readonly Dictionary<Type, object> ServiceCache;
        protected readonly IBaseServiceFactory<TUnitOfWork> ServiceFactory;
        protected readonly TUnitOfWork Uow;


        public BaseServiceProvider(IBaseServiceFactory<TUnitOfWork> serviceFactory, TUnitOfWork uow) : this(
            new Dictionary<Type, object>(), serviceFactory, uow)
        {
        }

        public BaseServiceProvider(Dictionary<Type, object> serviceCache,
            IBaseServiceFactory<TUnitOfWork> serviceFactory,
            TUnitOfWork uow)
        {
            ServiceCache = serviceCache;
            ServiceFactory = serviceFactory;
            Uow = uow;
        }

        public virtual TService GetService<TService>()
        {
            if (ServiceCache.ContainsKey(typeof(TService)))
            {
                return (TService) ServiceCache[typeof(TService)];
            }
            // didn't find the repo in cache, lets create it

            var repoCreationMethod = ServiceFactory.GetServiceFactory<TService>();


            object repo = repoCreationMethod(Uow);


            ServiceCache[typeof(TService)] = repo;
            return (TService) repo;
        }

        /*
        public virtual IBaseEntityService<TEntity> GetEntityService<TEntity>()
            where TEntity : class, IDomainEntity, new()
        {
            if (ServiceCache.ContainsKey(typeof(IBaseEntityService<TEntity>)))
            {
                return (IBaseEntityService<TEntity>) ServiceCache[typeof(IBaseEntityService<TEntity>)];
            }

            // didn't find the repo in cache, lets create it
            var repoCreationMethod = ServiceFactory.GetEntityServiceFactory<TEntity>();

            object repo = repoCreationMethod(Uow);


            ServiceCache[typeof(IBaseEntityService<TEntity>)] = repo;
            return (IBaseEntityService<TEntity>) repo;
        }
        */
        
    }
}
