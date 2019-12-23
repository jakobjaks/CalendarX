using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IEventTypeRepository : IEventTypeRepository<DALAppDTO.EventType>
    {
    }
    
    
    public interface IEventTypeRepository<TDALEntity> : IBaseRepository<TDALEntity>
        where TDALEntity : class, new()
    {

    }

    
}