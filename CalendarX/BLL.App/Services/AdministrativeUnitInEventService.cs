using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using AdministrativeUnitInEvent = BLL.App.DTO.AdministrativeUnitInEvent;

namespace BLL.App.Services
{
    public class AdministrativeUnitInEventService : BaseEntityService<BLL.App.DTO.AdministrativeUnitInEvent, DAL.App.DTO.AdministrativeUnitInEvent, IAppUnitOfWork>, IAdministrativeUnitInEventService
    {
        public AdministrativeUnitInEventService(IAppUnitOfWork uow) : base(uow, new AdministrativeUnitInEventMapper())
        {
            ServiceRepository = Uow.AdministrativeUnitInEvent;
        }



    }
}