using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using DAL.App.DTO;
using Event = BLL.App.DTO.Event;

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



        public async Task<List<Event>> SearchByCategory(string search, int type)
        {
            var list = new List<IEnumerable<DAL.App.DTO.Event>>();
            switch (type)
            {
                case 1:
                    return (await Uow.Event.FindByEventNameSearch(search)).Select(item => EventMapper.MapFromDAL(item)).ToList();
                    break;
                case 2:
                    list = await Uow.Event.FindByAdministrativeUnitSearch(search);
                    break;
                case 3:
                    list = await Uow.Event.FindByEventTypeSearch(search);
                    break;
                case 4:
                    list = await Uow.Event.FindByLocationSearch(search);
                    break;
                case 5:
                    list = await Uow.Event.FindByTargetAudienceSearch(search);
                    break;
                case 6:
                    list = await Uow.Event.FindByLocationSearch(search);
                    break;
                case 7:
                    list = await Uow.Event.FindByOrganizationSearch(search);
                    break;
                case 8:
                    list = await Uow.Event.FindBySponsorSearch(search);
                    break;
            }

            var union = new List<DAL.App.DTO.Event>();
            foreach (var t in list)
            {
                union = new List<DAL.App.DTO.Event>(union.Union(t, new EventComparer()));
            }


            return union.Select(item => EventMapper.MapFromDAL(item)).ToList();
        }


        public override Event Update(Event entity)
        {
            return EventMapper.MapFromDAL(ServiceRepository.Update(EventMapper.MapFromBLL(entity)));
        }

        public override Task<Event> AddAsync(Event entity)
        {
            
            
            return base.AddAsync(entity);
        }
        
        public Task<List<IEnumerable<DAL.App.DTO.Event>>> FindByAdministrativeUnitSearch(string search)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<IEnumerable<DAL.App.DTO.Event>>> FindByLocationSearch(string search)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<IEnumerable<DAL.App.DTO.Event>>> FindByEventTypeSearch(string search)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<IEnumerable<DAL.App.DTO.Event>>> FindByPerformerSearch(string search)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<IEnumerable<DAL.App.DTO.Event>>> FindByOrganizationSearch(string search)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<IEnumerable<DAL.App.DTO.Event>>> FindBySponsorSearch(string search)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<IEnumerable<DAL.App.DTO.Event>>> FindByAreaOfInterestSearch(string search)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<IEnumerable<DAL.App.DTO.Event>>> FindByTargetAudienceSearch(string search)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<DAL.App.DTO.Event>> FindByEventNameSearch(string search)
        {
            throw new System.NotImplementedException();
        }
    }
}