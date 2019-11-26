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
        
        //Todo: public facing services
    }
}