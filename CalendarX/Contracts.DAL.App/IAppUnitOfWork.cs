using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IBaseUnitOfWork
    {
        IAdministrativeUnitInEventRepository AdministrativeUnitInEvent { get; }
        IAdministrativeUnitRepository AdministrativeUnit { get; }
        IAreaOfInterestRepository AreaOfInterest  { get; }
        IEventInAreaOfInterestRepository EventInAreaOfInterest { get; }
        IEventInLocationRepository EventInLocation { get; }
        IEventTypeRepository EventType { get; }
        IEventRepository Event { get; }
        IEventTargetAudienceRepository EventTargetAudience { get; }
        IEventInTypeRepository EventInType { get; }
        ILocationRepository Location { get; }
        IOrganizationRepository Organization { get; }
        IOrganizationOrganizingRepository OrganizationOrganizing { get; }
        IPerformerInEventRepository PerformerInEvent { get; }
        IPerformerRepository Performer { get; }
        ISponsorInEventRepository SponsorInEvent { get; }
        ITargetAudienceRepository TargetAudience { get; }
    }
}