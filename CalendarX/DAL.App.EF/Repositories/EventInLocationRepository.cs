using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class EventInLocationRepository : BaseRepositoryAsync<EventInLocation>, IEventInLocationRepository
    {
        public EventInLocationRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}