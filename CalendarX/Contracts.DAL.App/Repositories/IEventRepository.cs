using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IEventRepository : IEventRepository<DALAppDTO.Event>
    {
    }
    
    
    public interface IEventRepository<TDALEntity> : IBaseRepository<TDALEntity>
        where TDALEntity : class, new()
    {
        Task<List<TDALEntity>> AllForUserAsync(int userId);
        Task<TDALEntity> FindForUserAsync(int id, int userId);
        Task<bool> BelongsToUserAsync(int id, int userId);
        Task<List<IEnumerable<DALAppDTO.Event>>> FindByAdministrativeUnitSearch(string search);
        Task<List<IEnumerable<DALAppDTO.Event>>> FindByLocationSearch(string search);
        Task<List<IEnumerable<DALAppDTO.Event>>> FindByEventTypeSearch(string search);
        Task<List<IEnumerable<DALAppDTO.Event>>> FindByPerformerSearch(string search);
        Task<List<IEnumerable<DALAppDTO.Event>>> FindByOrganizationSearch(string search);
        Task<List<IEnumerable<DALAppDTO.Event>>> FindBySponsorSearch(string search);
        Task<List<IEnumerable<DALAppDTO.Event>>> FindByAreaOfInterestSearch(string search);
        Task<List<IEnumerable<DALAppDTO.Event>>> FindByTargetAudienceSearch(string search);
        Task<List<DALAppDTO.Event>> FindByEventNameSearch(string search);
        Task<List<TDALEntity>> AllPastAsync();

    }

    
}