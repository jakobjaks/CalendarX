using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class EventRepository : BaseRepositoryAsync<Event>, IEventRepository
    {
        public EventRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}