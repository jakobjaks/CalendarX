using System;
using System.Collections.Generic;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.App.EF.Repositories;
using DAL.Base.EF;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Helpers;

namespace DAL.App.EF
{
    public class AppUnitOfWork : BaseUnitOfWork<AppDbContext>, IAppUnitOfWork
    {
        public AppUnitOfWork(AppDbContext dbContext, IBaseRepositoryProvider repositoryProvider) : base(dbContext,
            repositoryProvider)
        {
        }


        public IAdministrativeUnitInEventRepository AdministrativeUnitInEvent =>
            _repositoryProvider.GetRepository<IAdministrativeUnitInEventRepository>();


        public IAdministrativeUnitRepository AdministrativeUnit =>
            _repositoryProvider.GetRepository<IAdministrativeUnitRepository>();


        public IAreaOfInterestRepository AreaOfInterest =>
            _repositoryProvider.GetRepository<IAreaOfInterestRepository>();


        public IEventInAreaOfInterestRepository EventInAreaOfInterest =>
            _repositoryProvider.GetRepository<IEventInAreaOfInterestRepository>();


        public IEventInLocationRepository EventInLocation =>
            _repositoryProvider.GetRepository<IEventInLocationRepository>();


        public IEventTypeRepository EventType =>
            _repositoryProvider.GetRepository<IEventTypeRepository>();


        public IEventRepository Event =>
            _repositoryProvider.GetRepository<IEventRepository>();


        public IEventTargetAudienceRepository EventTargetAudience =>
            _repositoryProvider.GetRepository<IEventTargetAudienceRepository>();


        public IEventInTypeRepository EventInType =>
            _repositoryProvider.GetRepository<IEventInTypeRepository>();


        public ILocationRepository Location =>
            _repositoryProvider.GetRepository<ILocationRepository>();


        public IOrganizationRepository Organization =>
            _repositoryProvider.GetRepository<IOrganizationRepository>();


        public IOrganizationOrganizingRepository OrganizationOrganizing =>
            _repositoryProvider.GetRepository<IOrganizationOrganizingRepository>();


        public IPerformerInEventRepository PerformerInEvent =>
            _repositoryProvider.GetRepository<IPerformerInEventRepository>();


        public IPerformerRepository Performer =>
            _repositoryProvider.GetRepository<IPerformerRepository>();


        public ISponsorInEventRepository SponsorInEvent =>
            _repositoryProvider.GetRepository<ISponsorInEventRepository>();


        public ITargetAudienceRepository TargetAudience =>
            _repositoryProvider.GetRepository<ITargetAudienceRepository>();
    }
}