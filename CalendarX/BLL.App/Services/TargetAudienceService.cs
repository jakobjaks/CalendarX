using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Services
{
    public class TargetAudienceService :
        BaseEntityService<BLL.App.DTO.TargetAudience, DAL.App.DTO.TargetAudience, IAppUnitOfWork>,
        ITargetAudienceService
    {
        public TargetAudienceService(IAppUnitOfWork uow) : base(uow, new TargetAudienceMapper())
        {
            ServiceRepository =
                Uow.TargetAudience; //Uow.BaseRepository<DAL.App.DTO.TargetAudience, Domain.TargetAudience>();
        }
    }
}