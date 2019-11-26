using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class LocationRepository : BaseRepository<DAL.App.DTO.Location, Domain.Location, AppDbContext>,
        ILocationRepository
    {

        public LocationRepository(AppDbContext repositoryDbContext)
            : base(repositoryDbContext, new LocationMapper())
        {
        }


        public async Task<List<DAL.App.DTO.Location>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Select(e => LocationMapper.MapFromDomain(e)).ToListAsync();
        }

        public async Task<DAL.App.DTO.Location> FindForUserAsync(int id, int userId)
        {
            var Location = await RepositoryDbSet
                .FirstOrDefaultAsync(m => m.Id == id && m.AppUserId == userId);

            return LocationMapper.MapFromDomain(Location) ;
        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await RepositoryDbSet
                .AnyAsync(c => c.Id == id && c.AppUserId == userId);
        }
    }
}