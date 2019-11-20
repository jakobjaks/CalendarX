using System;
using System.Collections.Generic;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Repositories;
using DAL.Base.EF;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    public class AppUnitOfWork : BaseUnitOfWork, IAppUnitOfWork
    {
        private readonly Dictionary<Type, object> _repositoryCache = new Dictionary<Type, object>();
        
        public AppUnitOfWork(AppDbContext dbContext) : base(dbContext) {}


        private TRepository GetOrCreateRepository<TRepository>(Func<AppDbContext, TRepository> repoCreationMethod) where TRepository : class    
        {
            _repositoryCache.TryGetValue(typeof(TRepository), out var repoObject);
            if (repoObject != null)
            {
                return (TRepository) repoObject;
            }

            object repo = repoCreationMethod((AppDbContext) UOWDbContext);

            _repositoryCache[typeof(TRepository)] = repo;
            return (TRepository) repo;


        }



        public IAdministrativeUnitInEventRepository AdministrativeUnitInEventRepository =>
            GetOrCreateRepository<IAdministrativeUnitInEventRepository>((ctx) =>
                new AdministrativeUnitInEventRepository(ctx));
        public IAdministrativeUnitRepository AdministrativeUnitRepository =>
            GetOrCreateRepository<IAdministrativeUnitInEventRepository>((ctx) =>
                new AdministrativeUnitInEventRepository(ctx));        
        public IAreaOfInterestRepository AreaOfInterestRepository =>
            GetOrCreateRepository<IAdministrativeUnitInEventRepository>((ctx) =>
                new AdministrativeUnitInEventRepository(ctx));        
        public IEventInAreaOfInterestRepository EventInAreaOfInterestRepository =>
            GetOrCreateRepository<IAdministrativeUnitInEventRepository>((ctx) =>
                new AdministrativeUnitInEventRepository(ctx));
        
        public IEventInLocationRepository EventInLocationRepository =>
            GetOrCreateRepository<IAdministrativeUnitInEventRepository>((ctx) =>
                new AdministrativeUnitInEventRepository(ctx));
        public IEventTypeRepository EventTypeRepository =>
            GetOrCreateRepository<IAdministrativeUnitInEventRepository>((ctx) =>
                new AdministrativeUnitInEventRepository(ctx));
        
        public IEventRepository EventRepository =>
            GetOrCreateRepository<IAdministrativeUnitInEventRepository>((ctx) =>
                new AdministrativeUnitInEventRepository(ctx));
        public IEventTargetAudienceRepository EventTargetAudienceRepository =>
            GetOrCreateRepository<IAdministrativeUnitInEventRepository>((ctx) =>
                new AdministrativeUnitInEventRepository(ctx));
        public IEventInTypeRepository EventInTypeRepository =>
            GetOrCreateRepository<IAdministrativeUnitInEventRepository>((ctx) =>
                new AdministrativeUnitInEventRepository(ctx));
        
        public ILocationRepository LocationRepository =>
            GetOrCreateRepository<IAdministrativeUnitInEventRepository>((ctx) =>
                new AdministrativeUnitInEventRepository(ctx));
        public IOrganizationRepository OrganizationRepository =>
            GetOrCreateRepository<IAdministrativeUnitInEventRepository>((ctx) =>
                new AdministrativeUnitInEventRepository(ctx));
        
        public IOrganizationOrganizingRepository OrganizationOrganizingRepository =>
            GetOrCreateRepository<IAdministrativeUnitInEventRepository>((ctx) =>
                new AdministrativeUnitInEventRepository(ctx));
        public IPerformerInEventRepository PerformerInEventRepository =>
            GetOrCreateRepository<IAdministrativeUnitInEventRepository>((ctx) =>
                new AdministrativeUnitInEventRepository(ctx));
        
        public IPerformerRepository PerformerRepository =>
            GetOrCreateRepository<IAdministrativeUnitInEventRepository>((ctx) =>
                new AdministrativeUnitInEventRepository(ctx));
        public ISponsorInEventRepository SponsorInEventRepository =>
            GetOrCreateRepository<IAdministrativeUnitInEventRepository>((ctx) =>
                new AdministrativeUnitInEventRepository(ctx));
        public ITargetAudienceRepository TargetAudienceRepository =>
            GetOrCreateRepository<IAdministrativeUnitInEventRepository>((ctx) =>
                new AdministrativeUnitInEventRepository(ctx));
    }
}