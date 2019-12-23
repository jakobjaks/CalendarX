using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class EventTypeRepository : BaseRepository<DAL.App.DTO.EventType, Domain.EventType, AppDbContext>,
        IEventTypeRepository
    {

        public EventTypeRepository(AppDbContext repositoryDbContext)
            : base(repositoryDbContext, new EventTypeMapper())
        {
        }
        
    }
}