using System;
using System.Collections.Generic;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Helpers;
using Contracts.DAL.Base.Repositories;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Base.EF.Helpers
{
    public class BaseRepositoryProvider<TDbContext> : IBaseRepositoryProvider
    where TDbContext: DbContext
    {
        protected readonly Dictionary<Type, object> _repositoryCache;
        protected readonly IBaseRepositoryFactory<TDbContext> _repositoryFactory;
        protected readonly TDbContext DataContext;
        
        public BaseRepositoryProvider(IBaseRepositoryFactory<TDbContext> repositoryFactory, TDbContext dataContext):
            this(new Dictionary<Type, object>(), repositoryFactory, dataContext)
        {
        }
        
        public BaseRepositoryProvider(Dictionary<Type, object> repositoryCache, IBaseRepositoryFactory<TDbContext> repositoryFactory, TDbContext dataContext)
        {
            _repositoryCache = repositoryCache;
            _repositoryFactory = repositoryFactory;
            DataContext = dataContext;
        }

        public virtual TRepository GetRepository<TRepository>()
        {
            if (_repositoryCache.ContainsKey(typeof(TRepository)))
            {
                return (TRepository) _repositoryCache[typeof(TRepository)];
            }
            // didn't find the repo in cache, lets create it

            var repoCreationMethod = _repositoryFactory.GetRepositoryFactory<TRepository>();


            object repo = repoCreationMethod(DataContext);
        

            _repositoryCache[typeof(TRepository)] = repo;
            return (TRepository) repo;
        }


        public virtual IBaseRepository<TDALEntity> GetEntityRepository<TDALEntity, TDomainEntity>() 
            where TDALEntity : class, new()
            where TDomainEntity : class, IDomainEntity, new()
        {
            if (_repositoryCache.ContainsKey(typeof(IBaseRepositoryAsync<TDALEntity>)))
            {
                return (IBaseRepository<TDALEntity>) _repositoryCache[typeof(IBaseRepositoryAsync<TDALEntity>)];
            }
            // didn't find the repo in cache, lets create it
            var repoCreationMethod = _repositoryFactory.GetEntityRepositoryFactory<TDALEntity, TDomainEntity>();

            object repo = repoCreationMethod(DataContext);


            _repositoryCache[typeof(IBaseRepositoryAsync<TDALEntity>)] = repo;
            return (IBaseRepository<TDALEntity>) repo;

        }


    }
}
