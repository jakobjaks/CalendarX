using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Services
{
    public class EventTypeService : BaseEntityService<BLL.App.DTO.EventType, DAL.App.DTO.EventType, IAppUnitOfWork>, IEventTypeService
    {
        public EventTypeService(IAppUnitOfWork uow) : base(uow, new EventTypeMapper())
        {
            ServiceRepository = Uow.EventType;  //Uow.BaseRepository<DAL.App.DTO.EventType, Domain.EventType>();
        }


    }
}