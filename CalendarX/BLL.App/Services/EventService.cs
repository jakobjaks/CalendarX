using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Services
{
    public class EventService : BaseEntityService<BLL.App.DTO.Event, DAL.App.DTO.Event, IAppUnitOfWork>, IEventService
    {
        public EventService(IAppUnitOfWork uow) : base(uow, new EventMapper())
        {
            ServiceRepository = Uow.Event;  //Uow.BaseRepository<DAL.App.DTO.Event, Domain.Event>();
        }

        public async Task<List<BLL.App.DTO.Event>> AllForUserAsync(int userId)
        {
            return (await Uow.Event.AllForUserAsync(userId)).Select(e => EventMapper.MapFromDAL(e)).ToList();
        }

        public async Task<BLL.App.DTO.Event> FindForUserAsync(int id, int userId)
        {
            return EventMapper.MapFromDAL( await Uow.Event.FindForUserAsync(id, userId));
        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await Uow.Event.BelongsToUserAsync(id, userId);
        }
    }
}