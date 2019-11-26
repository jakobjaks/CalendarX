//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Contracts.DAL.App.Repositories;
//using DAL.App.EF.Mappers;
//using DAL.Base.EF.Repositories;
//using Microsoft.EntityFrameworkCore;
//
//namespace DAL.App.EF.Repositories
//{
//    public class AdministrativeUnitInEventRepository : BaseRepository<DAL.App.DTO.AdministrativeUnitInEvent, Domain.AdministrativeUnitInEvent, AppDbContext>,
//        IAdministrativeUnitInEventRepository
//    {
//
//        public AdministrativeUnitInEventRepository(AppDbContext repositoryDbContext)
//            : base(repositoryDbContext, new AdministrativeUnitInEventMapper())
//        {
//        }
//
//
//        public async Task<List<DAL.App.DTO.AdministrativeUnitInEvent>> AllForUserAsync(int userId)
//        {
//            return await RepositoryDbSet
//                .Include(c => c.AdministrativeUnitInEventType)
//                .ThenInclude(m => m.AdministrativeUnitInEventTypeValue)
//                .ThenInclude(t => t.Translations)
//                .Include(c => c.Person)
//                .Where(c => c.Person.AppUserId == userId)
//                .Select(e => AdministrativeUnitInEventMapper.MapFromDomain(e)).ToListAsync();
//        }
//
//        public async Task<DAL.App.DTO.AdministrativeUnitInEvent> FindForUserAsync(int id, int userId)
//        {
//            var contact = await RepositoryDbSet
//                .Include(c => c.AdministrativeUnitInEventType)
//                .ThenInclude(m => m.AdministrativeUnitInEventTypeValue)
//                .ThenInclude(t => t.Translations)
//                .Include(c => c.Person)
//                .FirstOrDefaultAsync(m => m.Id == id && m.Person.AppUserId == userId);
//
//            return AdministrativeUnitInEventMapper.MapFromDomain(contact) ;
//        }
//
//        public async Task<bool> BelongsToUserAsync(int id, int userId)
//        {
//            return await RepositoryDbSet
//                .AnyAsync(c => c.Id == id && c.Person.AppUserId == userId);
//        }
//    }
//}