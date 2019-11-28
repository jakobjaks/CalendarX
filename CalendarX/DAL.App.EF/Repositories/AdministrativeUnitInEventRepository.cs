using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using AdministrativeUnit = BLL.App.DTO.AdministrativeUnit;
using AdministrativeUnitInEvent = DAL.App.DTO.AdministrativeUnitInEvent;

namespace DAL.App.EF.Repositories
{
    public class AdministrativeUnitInEventRepository : BaseRepository<DAL.App.DTO.AdministrativeUnitInEvent, Domain.AdministrativeUnitInEvent, AppDbContext>,
        IAdministrativeUnitInEventRepository
    {

        public AdministrativeUnitInEventRepository(AppDbContext repositoryDbContext)
            : base(repositoryDbContext, new AdministrativeUnitInEventMapper())
        {
        }


        public async void RemoveAllForEvent(int eventId)
        {
            var list = await RepositoryDbSet
                .Where(item => item.EventId == eventId)
                .Select(e => AdministrativeUnitInEventMapper.MapFromDomain(e)).ToListAsync();
            foreach (var item in list)
            {
                RepositoryDbSet.Remove(AdministrativeUnitInEventMapper.MapFromDAL(item));
            }
        }

        public void AddAllForEvent(ICollection<AdministrativeUnit> units, int entityId)
        {
            throw new System.NotImplementedException();
        }

//        public async void Sync(ICollection<AdministrativeUnit> units, int entityId)
//        {
//            var list = await RepositoryDbSet
//                .Where(item => item.EventId == entityId)
//                .Include(item => item.AdministrativeUnitId)
//                .Include(item => item.EventId)
//                .Select(e => AdministrativeUnitInEventMapper.MapFromDomain(e)).ToListAsync();
//            var idList = ToIdCollection(list);
//            foreach (var unit in units)
//            {
//                if (!idList.Contains(unit.Id))
//                {
//                    
//                }
//                
//
//            }
//        }
//
//        private ICollection<int> ToIdCollection(ICollection<AdministrativeUnitInEvent> administrativeUnitsInEvent)
//        {
//            var list = new List<int>();
//            foreach (var administrativeUnitInEvent in administrativeUnitsInEvent)
//            {
//                list.Add(administrativeUnitInEvent.AdministrativeUnitId);
//            }
//
//            return list;
//        }
    }
}