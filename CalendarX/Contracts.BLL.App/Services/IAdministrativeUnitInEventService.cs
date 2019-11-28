using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using BLL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface IAdministrativeUnitInEventService : IBaseEntityService<AdministrativeUnitInEvent>, IAdministrativeUnitInEventRepository<AdministrativeUnitInEvent>
    {


    }
}