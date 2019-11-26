using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class AdministrativeUnitRepository : BaseRepository<DAL.App.DTO.AdministrativeUnit, Domain.AdministrativeUnit, AppDbContext>,
        IAdministrativeUnitRepository
    {

        public AdministrativeUnitRepository(AppDbContext repositoryDbContext)
            : base(repositoryDbContext, new AdministrativeUnitMapper())
        {
        }


        public async Task<List<DAL.App.DTO.AdministrativeUnit>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Select(e => AdministrativeUnitMapper.MapFromDomain(e)).ToListAsync();
        }

        public async Task<DAL.App.DTO.AdministrativeUnit> FindForUserAsync(int id, int userId)
        {
            var AdministrativeUnit = await RepositoryDbSet
                .FirstOrDefaultAsync(m => m.Id == id && m.AppUserId == userId);

            return AdministrativeUnitMapper.MapFromDomain(AdministrativeUnit) ;
        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await RepositoryDbSet
                .AnyAsync(c => c.Id == id && c.AppUserId == userId);
        }
    }
}