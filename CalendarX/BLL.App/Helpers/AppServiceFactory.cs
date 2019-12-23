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
            AddToCreationMethods<IAdministrativeUnitInEventService>(uow => new AdministrativeUnitInEventService(uow));
            AddToCreationMethods<IAdministrativeUnitService>(uow => new AdministrativeUnitService(uow));
            AddToCreationMethods<IEventTypeService>(uow => new EventTypeService(uow));

        }
       
      
    }
    
}