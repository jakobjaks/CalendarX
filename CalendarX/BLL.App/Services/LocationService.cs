using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Services
{
    public class LocationService : BaseEntityService<BLL.App.DTO.Location, DAL.App.DTO.Location, IAppUnitOfWork>, ILocationService
    {
        public LocationService(IAppUnitOfWork uow) : base(uow, new LocationMapper())
        {
            ServiceRepository = Uow.Location;  //Uow.BaseRepository<DAL.App.DTO.Location, Domain.Location>();
        }

        public async Task<List<BLL.App.DTO.Location>> AllForUserAsync(int userId)
        {
            return (await Uow.Location.AllForUserAsync(userId)).Select(e => LocationMapper.MapFromDAL(e)).ToList();
        }

        public async Task<BLL.App.DTO.Location> FindForUserAsync(int id, int userId)
        {
            return LocationMapper.MapFromDAL( await Uow.Location.FindForUserAsync(id, userId));
        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await Uow.Location.BelongsToUserAsync(id, userId);
        }
    }
}