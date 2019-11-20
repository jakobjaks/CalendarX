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
            GetOrCreateRepository<IAdministrativeUnitRepository>((ctx) =>
                new AdministrativeUnitRepository(ctx));        
        public IAreaOfInterestRepository AreaOfInterestRepository =>
            GetOrCreateRepository<IAreaOfInterestRepository>((ctx) =>
                new AreaOfInterestRepository(ctx));        
        public IEventInAreaOfInterestRepository EventInAreaOfInterestRepository =>
            GetOrCreateRepository<IEventInAreaOfInterestRepository>((ctx) =>
                new EventInAreaOfInterestRepository(ctx));
        
        public IEventInLocationRepository EventInLocationRepository =>
            GetOrCreateRepository<IEventInLocationRepository>((ctx) =>
                new EventInLocationRepository(ctx));
        public IEventTypeRepository EventTypeRepository =>
            GetOrCreateRepository<IEventTypeRepository>((ctx) =>
                new EventTypeRepository(ctx));
        
        public IEventRepository EventRepository =>
            GetOrCreateRepository<IEventRepository>((ctx) =>
                new EventRepository(ctx));
        public IEventTargetAudienceRepository EventTargetAudienceRepository =>
            GetOrCreateRepository<IEventTargetAudienceRepository>((ctx) =>
                new EventTargetAudienceRepository(ctx));
        public IEventInTypeRepository EventInTypeRepository =>
            GetOrCreateRepository<IEventInTypeRepository>((ctx) =>
                new EventInTypeRepository(ctx));
        
        public ILocationRepository LocationRepository =>
            GetOrCreateRepository<ILocationRepository>((ctx) =>
                new LocationRepository(ctx));
        public IOrganizationRepository OrganizationRepository =>
            GetOrCreateRepository<IOrganizationRepository>((ctx) =>
                new OrganizationRepository(ctx));
        
        public IOrganizationOrganizingRepository OrganizationOrganizingRepository =>
            GetOrCreateRepository<IOrganizationOrganizingRepository>((ctx) =>
                new OrganizationOrganizingRepository(ctx));
        public IPerformerInEventRepository PerformerInEventRepository =>
            GetOrCreateRepository<IPerformerInEventRepository>((ctx) =>
                new PerformerInEventRepository(ctx));
        
        public IPerformerRepository PerformerRepository =>
            GetOrCreateRepository<IPerformerRepository>((ctx) =>
                new PerformerRepository(ctx));
        public ISponsorInEventRepository SponsorInEventRepository =>
            GetOrCreateRepository<ISponsorInEventRepository>((ctx) =>
                new SponsorInEventRepository(ctx));
        public ITargetAudienceRepository TargetAudienceRepository =>
            GetOrCreateRepository<ITargetAudienceRepository>((ctx) =>
                new TargetAudienceRepository(ctx));
    }
}