using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using BLL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface IAdministrativeUnitService : IBaseEntityService<AdministrativeUnit>, IAdministrativeUnitRepository<AdministrativeUnit>
    {
        
    }
}