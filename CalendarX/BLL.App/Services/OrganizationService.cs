using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Services
{
    public class OrganizationService :
        BaseEntityService<BLL.App.DTO.Organization, DAL.App.DTO.Organization, IAppUnitOfWork>, IOrganizationService
    {
        public OrganizationService(IAppUnitOfWork uow) : base(uow, new OrganizationMapper())
        {
            ServiceRepository = Uow.Organization; //Uow.BaseRepository<DAL.App.DTO.Organization, Domain.Organization>();
        }
    }
}