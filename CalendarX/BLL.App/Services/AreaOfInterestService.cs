using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Services
{
    public class AreaOfInterestService : BaseEntityService<BLL.App.DTO.AreaOfInterest, DAL.App.DTO.AreaOfInterest, IAppUnitOfWork>, IAreaOfInterestService
    {
        public AreaOfInterestService(IAppUnitOfWork uow) : base(uow, new AreaOfInterestMapper())
        {
            ServiceRepository = Uow.AreaOfInterest;  //Uow.BaseRepository<DAL.App.DTO.AreaOfInterest, Domain.AreaOfInterest>();
        }
        
    }
}