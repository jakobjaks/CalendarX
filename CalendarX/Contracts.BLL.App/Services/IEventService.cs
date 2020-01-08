using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;

namespace Contracts.BLL.App.Services
{
    public interface IEventService : IBaseEntityService<Event>, IEventRepository<Event>
    {
        public Task<List<Event>> SearchByCategory(string search, int type);
    }
}