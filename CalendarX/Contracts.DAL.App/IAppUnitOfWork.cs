using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IBaseUnitOfWork
    {
        IAdministrativeUnitInEventRepository AdministrativeUnitInEventRepository { get; }
        IAdministrativeUnitRepository AdministrativeUnitRepository { get; }
        IAreaOfInterestRepository AreaOfInterestRepository  { get; }
        IEventInAreaOfInterestRepository EventInAreaOfInterestRepository { get; }
        IEventInLocationRepository EventInLocationRepository { get; }
        IEventTypeRepository EventTypeRepository { get; }
        IEventRepository EventRepository { get; }
        IEventTargetAudienceRepository EventTargetAudienceRepository { get; }
        IEventInTypeRepository EventInTypeRepository { get; }
        ILocationRepository LocationRepository { get; }
        IOrganizationRepository OrganizationRepository { get; }
        IOrganizationOrganizingRepository OrganizationOrganizingRepository { get; }
        IPerformerInEventRepository PerformerInEventRepository { get; }
        IPerformerRepository PerformerRepository { get; }
        ISponsorInEventRepository SponsorInEventRepository { get; }
        ITargetAudienceRepository TargetAudienceRepository { get; }
    }
}