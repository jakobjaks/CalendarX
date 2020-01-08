using System;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base;

namespace Contracts.BLL.App
{
    public interface IAppBLL : IBaseBLL
    {
        IEventService Events { get; }
        ILocationService Locations { get; }
        IAdministrativeUnitService AdministrativeUnits { get; }
        IEventTypeService EventTypes { get; }
        ITargetAudienceService TargetAudiences { get; }
        IPerformerService Performers { get; }
        IOrganizationService Organizations { get; }
        IAreaOfInterestService AreaOfInterests { get; }
        
        //Todo: public facing services
    }
}