using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class EventTypeRepository : BaseRepositoryAsync<EventType>, IEventTypeRepository
    {
        public EventTypeRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}