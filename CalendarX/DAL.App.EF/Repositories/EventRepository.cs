using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class EventRepository : BaseRepository<DAL.App.DTO.Event, Domain.Event, AppDbContext>,
        IEventRepository
    {

        public EventRepository(AppDbContext repositoryDbContext)
            : base(repositoryDbContext, new EventMapper())
        {
        }


        public async Task<List<DAL.App.DTO.Event>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(c => c.EventLocations)
                .Select(e => EventMapper.MapFromDomain(e)).ToListAsync();
        }

        public async Task<DAL.App.DTO.Event> FindForUserAsync(int id, int userId)
        {
            var Event = await RepositoryDbSet
                .FirstOrDefaultAsync(m => m.Id == id && m.AppUserId == userId);

            return EventMapper.MapFromDomain(Event) ;
        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await RepositoryDbSet
                .AnyAsync(c => c.Id == id && c.AppUserId == userId);
        }
    }
}