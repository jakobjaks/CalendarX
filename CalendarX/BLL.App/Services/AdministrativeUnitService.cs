using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Services
{
    public class AdministrativeUnitService : BaseEntityService<BLL.App.DTO.AdministrativeUnit, DAL.App.DTO.AdministrativeUnit, IAppUnitOfWork>, IAdministrativeUnitService
    {
        public AdministrativeUnitService(IAppUnitOfWork uow) : base(uow, new AdministrativeUnitMapper())
        {
            ServiceRepository = Uow.AdministrativeUnit;  //Uow.BaseRepository<DAL.App.DTO.AdministrativeUnit, Domain.AdministrativeUnit>();
        }

        public async Task<List<BLL.App.DTO.AdministrativeUnit>> AllForUserAsync(int userId)
        {
            return (await Uow.AdministrativeUnit.AllForUserAsync(userId)).Select(e => AdministrativeUnitMapper.MapFromDAL(e)).ToList();
        }

        public async Task<BLL.App.DTO.AdministrativeUnit> FindForUserAsync(int id, int userId)
        {
            return AdministrativeUnitMapper.MapFromDAL( await Uow.AdministrativeUnit.FindForUserAsync(id, userId));
        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await Uow.AdministrativeUnit.BelongsToUserAsync(id, userId);
        }
    }
}