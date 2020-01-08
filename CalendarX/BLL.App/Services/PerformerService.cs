using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Services
{
    public class PerformerService :
        BaseEntityService<BLL.App.DTO.Performer, DAL.App.DTO.Performer, IAppUnitOfWork>, IPerformerService
    {
        public PerformerService(IAppUnitOfWork uow) : base(uow, new PerformerMapper())
        {
            ServiceRepository = Uow.Performer; //Uow.BaseRepository<DAL.App.DTO.Performer, Domain.Performer>();
        }
    }
}