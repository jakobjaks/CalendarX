using Contracts.DAL.App.Repositories;
using DAL.App.EF.Repositories;
using DAL.Base.EF.Helpers;

namespace DAL.App.EF.Helpers
{
    public class AppRepositoryFactory : BaseRepositoryFactory<AppDbContext>
    {
        public AppRepositoryFactory()
        {
            RegisterRepositories();
        }

        private void RegisterRepositories()
        {
            AddToCreationMethods<IEventRepository>(dataContext => new EventRepository(dataContext));
            AddToCreationMethods<IAdministrativeUnitInEventRepository>(dataContext => new AdministrativeUnitInEventRepository(dataContext));
            AddToCreationMethods<ILocationRepository>(dataContext => new LocationRepository(dataContext));
            AddToCreationMethods<IAdministrativeUnitRepository>(dataContext => new AdministrativeUnitRepository(dataContext));
            AddToCreationMethods<IEventTypeRepository>(dataContext => new EventTypeRepository(dataContext));

        }
    }
    
    
}