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
        
        
        public override async Task<List<DAL.App.DTO.Event>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(item => item.EventAdministrativeUnit)
                .ThenInclude(item => item.AdministrativeUnit)
                .Select(e => EventMapper.MapFromDomain(e)).ToListAsync();
        }

        public async Task<List<DAL.App.DTO.Event>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(item => item.EventAdministrativeUnit)
                .ThenInclude(item => item.AdministrativeUnit)
                .Select(e => EventMapper.MapFromDomain(e)).ToListAsync();
        }

        public async Task<DAL.App.DTO.Event> FindForUserAsync(int id, int userId)
        {
            var Event = await RepositoryDbSet
                .Include(item => item.EventAdministrativeUnit)
                .ThenInclude(item => item.AdministrativeUnit)
                .FirstOrDefaultAsync(m => m.Id == id && m.AppUserId == userId);

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
    }
}