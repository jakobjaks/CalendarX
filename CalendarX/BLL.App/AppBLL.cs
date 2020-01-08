using System;
using BLL.Base;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base.Helpers;
using Contracts.DAL.App;
using Contracts.DAL.Base;
using Microsoft.Extensions.DependencyInjection;

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
        public IEventTypeService EventTypes => ServiceProvider.GetService<IEventTypeService>();
        public ITargetAudienceService TargetAudiences => ServiceProvider.GetService<ITargetAudienceService>();
        public IPerformerService Performers => ServiceProvider.GetService<IPerformerService>();
        public IOrganizationService Organizations => ServiceProvider.GetService<IOrganizationService>();
        public IAreaOfInterestService AreaOfInterests => ServiceProvider.GetService<IAreaOfInterestService>();
        public ILocationService Locations => ServiceProvider.GetService<ILocationService>();
        
    }
}