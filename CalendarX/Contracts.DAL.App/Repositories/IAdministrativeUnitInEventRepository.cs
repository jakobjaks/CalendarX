using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IAdministrativeUnitInEventRepository : IAdministrativeUnitInEventRepository<DALAppDTO.AdministrativeUnitInEvent>
    {
    }
    
    
    public interface IAdministrativeUnitInEventRepository<TDALEntity> : IBaseRepository<TDALEntity>
        where TDALEntity : class, new()
    {


    }

    
}