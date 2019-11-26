using System;
using BLL.Base;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base.Helpers;
using Contracts.DAL.App;
using Contracts.DAL.Base;

namespace BLL.App
{
    public class AppBLL : BaseBLL<IAppUnitOfWork>, IAppBLL
    {
        protected readonly IAppUnitOfWork AppUnitOfWork;
        
        public AppBLL(IAppUnitOfWork appUnitOfWork, IBaseServiceProvider serviceProvider) : base(appUnitOfWork, serviceProvider)
        {
            AppUnitOfWork = appUnitOfWork;
        }

        public IEventService Events => ServiceProvider.GetService<IEventService>();
        public IAdministrativeUnitService AdministrativeUnits => ServiceProvider.GetService<IAdministrativeUnitService>();
        public ILocationService Locations => ServiceProvider.GetService<ILocationService>();
        
    }
}