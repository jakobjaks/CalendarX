using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IPerformerRepository : IPerformerRepository<DALAppDTO.Performer>
    {
    }
    
    
    public interface IPerformerRepository<TDALEntity> : IBaseRepository<TDALEntity>
        where TDALEntity : class, new()
    {

    }

    
}