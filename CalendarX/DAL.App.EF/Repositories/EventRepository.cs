using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Event = DAL.App.DTO.Event;

namespace DAL.App.EF.Repositories
{
    public class EventRepository : BaseRepository<DAL.App.DTO.Event, Domain.Event, AppDbContext>,
        IEventRepository
    {

        public EventRepository(AppDbContext repositoryDbContext)
            : base(repositoryDbContext, new EventMapper())
        {
        }
        
        public override async Task<Event> AddAsync(Event entity)
        {
            //EntityCreationCache
            var res = (await RepositoryDbSet.AddAsync(EventMapper.MapFromDAL(entity))).Entity;
            EntityCreationCache.Add(res.Id, res);
            return EventMapper.MapFromDomain(res);
        }

        public override async Task<List<DAL.App.DTO.Event>> AllAsync()
        {
            return await RepositoryDbSet
                .Where(item => DateTime.Compare(item.EventDate, DateTime.Now) != -1)
                .Select(e => EventMapper.MapFromDomain(e)).ToListAsync();
        }
        
        public async Task<List<Event>> AllPastAsync()
        {
            return await RepositoryDbSet
                .Select(e => EventMapper.MapFromDomain(e)).ToListAsync();        
        }
        
        public async Task<List<DAL.App.DTO.Event>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(item => item.EventAdministrativeUnit)
                .ThenInclude(item => item.AdministrativeUnit)
                .Include(item => item.EventLocations)
                .ThenInclude(item => item.Location)
                .Include(item => item.EventOrganizers)
                .ThenInclude(item => item.Organization)
                .Include(item => item.EventPerformers)
                .ThenInclude(item => item.Performer)
                .Include(item => item.EventSponsors)
                .ThenInclude(item => item.Organization)
                .Include(item => item.EventTypes)
                .ThenInclude(item => item.EventType)
                .Select(e => EventMapper.MapFromDomain(e)).ToListAsync();
        }

        public async Task<DAL.App.DTO.Event> FindForUserAsync(int id, int userId)
        {
            var Event = await RepositoryDbSet
                .Include(item => item.EventAdministrativeUnit)
                .ThenInclude(item => item.AdministrativeUnit)
                .Include(item => item.EventLocations)
                .ThenInclude(item => item.Location)
                .Include(item => item.EventOrganizers)
                .ThenInclude(item => item.Organization)
                .Include(item => item.EventPerformers)
                .ThenInclude(item => item.Performer)
                .Include(item => item.EventSponsors)
                .ThenInclude(item => item.Organization)
                .Include(item => item.EventTypes)
                .ThenInclude(item => item.EventType)
                .FirstOrDefaultAsync(m => m.Id == id && m.AppUserId == userId);

            return EventMapper.MapFromDomain(Event) ;
        }

        public async Task<Event> FindAsync(params object[] id)
        {
            var Event = await RepositoryDbSet
                .Include(item => item.EventAdministrativeUnit)
                .ThenInclude(item => item.AdministrativeUnit)
                .Include(item => item.EventLocations)
                .ThenInclude(item => item.Location)
                .Include(item => item.EventOrganizers)
                .ThenInclude(item => item.Organization)
                .Include(item => item.EventPerformers)
                .ThenInclude(item => item.Performer)
                .Include(item => item.EventSponsors)
                .ThenInclude(item => item.Organization)
                .Include(item => item.EventTypes)
                .ThenInclude(item => item.EventType)
                .FirstOrDefaultAsync(m => m.Id == (int) id[0]);

            return EventMapper.MapFromDomain(Event) ;        
        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await RepositoryDbSet
                .AnyAsync(c => c.Id == id && c.AppUserId == userId);
        }
        
        
        public override Event Update(Event entity)
        {
            var dbUnit = RepositoryDbContext.AdministrativeUnitInEvents.Where(item => item.EventId == entity.Id).ToList();
            RepositoryDbContext.RemoveRange(dbUnit);
            var dbType = RepositoryDbContext.EventInTypes.Where(item => item.EventId == entity.Id).ToList();
            RepositoryDbContext.RemoveRange(dbType);
            return EventMapper.MapFromDomain(RepositoryDbSet.Update(EventMapper.MapFromDAL(entity)).Entity);
        }

        public async Task<List<IEnumerable<Event>>> FindByAdministrativeUnitSearch(string search)
        {
            var events = await RepositoryDbContext.AdministrativeUnits
                .Include(item => item.EventsInAdministrativeUnit)
                .ThenInclude(item => item.Event)
                .ThenInclude(item => item.EventLocations)
                .ThenInclude(item => item.Location)
                .Where(item => item.Name.Contains(search))
                .Select(item => item.EventsInAdministrativeUnit.Select(item => EventMapper.MapFromDomain(item.Event)))
                .ToListAsync();
            

            return events;
        }
        
        public async Task<List<IEnumerable<Event>>> FindByLocationSearch(string search)
        {
            var events = await RepositoryDbContext.Locations
                .Include(item => item.EventsInLocation)
                .ThenInclude(item => item.Event)
                .ThenInclude(item => item.EventLocations)
                .ThenInclude(item => item.Location)
                .Where(item => item.Name.Contains(search))
                .Select(item => item.EventsInLocation.Select(item => EventMapper.MapFromDomain(item.Event)))
                .ToListAsync();

            return events;
        }
        
        public async Task<List<IEnumerable<Event>>> FindByEventTypeSearch(string search)
        {
            var events = await RepositoryDbContext.EventTypes
                .Include(item => item.EventsInType)
                .ThenInclude(item => item.Event)
                .ThenInclude(item => item.EventLocations)
                .ThenInclude(item => item.Location)
                .Where(item => item.Name.Contains(search))
                .Select(item => item.EventsInType.Select(item => EventMapper.MapFromDomain(item.Event)))
                .ToListAsync();

            return events;
        }
        
        public async Task<List<IEnumerable<Event>>> FindByPerformerSearch(string search)
        {
            var events = await RepositoryDbContext.Performers
                .Include(item => item.Type)
                .ThenInclude(item => item.Event)
                .ThenInclude(item => item.EventLocations)
                .ThenInclude(item => item.Location)
                .Where(item => item.Name.Contains(search))
                .Select(item => item.Type.Select(item => EventMapper.MapFromDomain(item.Event)))
                .ToListAsync();

            return events;
        }
        
        public async Task<List<IEnumerable<Event>>> FindByOrganizationSearch(string search)
        {
            var events = await RepositoryDbContext.Organizations
                .Include(item => item.EventsOrganized)
                .ThenInclude(item => item.Event)
                .ThenInclude(item => item.EventLocations)
                .ThenInclude(item => item.Location)
                .Where(item => item.Name.Contains(search))
                .Select(item => item.EventsOrganized.Select(item => EventMapper.MapFromDomain(item.Event)))
                .ToListAsync();

            return events;
        }
        
        public async Task<List<IEnumerable<Event>>> FindBySponsorSearch(string search)
        {
            var events = await RepositoryDbContext.Organizations
                .Include(item => item.EventsSponsored)
                .ThenInclude(item => item.Event)
                .ThenInclude(item => item.EventLocations)
                .ThenInclude(item => item.Location)
                .Where(item => item.Name.Contains(search))
                .Select(item => item.EventsSponsored.Select(item => EventMapper.MapFromDomain(item.Event)))
                .ToListAsync();

            return events;
        }
        
        public async Task<List<IEnumerable<Event>>> FindByAreaOfInterestSearch(string search)
        {
            var events = await RepositoryDbContext.AreaOfInterests
                .Include(item => item.EventsInAreaOfInterest)
                .ThenInclude(item => item.Event)
                .ThenInclude(item => item.EventLocations)
                .ThenInclude(item => item.Location)
                .Where(item => item.Name.Contains(search))
                .Select(item => item.EventsInAreaOfInterest.Select(item => EventMapper.MapFromDomain(item.Event)))
                .ToListAsync();

            return events;
        }
        
        public async Task<List<IEnumerable<Event>>> FindByTargetAudienceSearch(string search)
        {
            var events = await RepositoryDbContext.TargetAudiences
                .Include(item => item.EventsForTargetAudience)
                .ThenInclude(item => item.Event)
                .ThenInclude(item => item.EventLocations)
                .ThenInclude(item => item.Location)
                .Where(item => item.Name.Contains(search))
                .Select(item => item.EventsForTargetAudience.Select(item => EventMapper.MapFromDomain(item.Event)))
                .ToListAsync();

            return events;
        }
        
        public async Task<List<Event>> FindByEventNameSearch(string search)
        {
            var events = await RepositoryDbContext.Events
                .Include(item => item.EventOrganizers)
                .ThenInclude(item => item.Event)
                .ThenInclude(item => item.EventLocations)
                .ThenInclude(item => item.Location)
                .Where(item => item.Name.Contains(search))
                .Select(item => EventMapper.MapFromDomain(item))
                .ToListAsync();

            return events;
        }


    }
}