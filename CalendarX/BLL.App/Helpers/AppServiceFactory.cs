using BLL.App.Services;
using BLL.Base.Helpers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Helpers
{
    public class AppServiceFactory : BaseServiceFactory<IAppUnitOfWork>
    {
        public AppServiceFactory()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {

            // Register all your custom services here!
            AddToCreationMethods<ILocationService>(uow => new LocationService(uow));
            AddToCreationMethods<IEventService>(uow => new EventService(uow));
            AddToCreationMethods<IAdministrativeUnitService>(uow => new AdministrativeUnitService(uow));
            AddToCreationMethods<IEventTypeService>(uow => new EventTypeService(uow));
            AddToCreationMethods<IOrganizationService>(uow => new OrganizationService(uow));
            AddToCreationMethods<ITargetAudienceService>(uow => new TargetAudienceService(uow));
            AddToCreationMethods<IAreaOfInterestService>(uow => new AreaOfInterestService(uow));
            AddToCreationMethods<IPerformerService>(uow => new PerformerService(uow));


        }
       
      
    }
    
}