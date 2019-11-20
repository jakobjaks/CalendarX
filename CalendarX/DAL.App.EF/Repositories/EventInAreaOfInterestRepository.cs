using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class EventInAreaOfInterestRepository : BaseRepositoryAsync<EventInAreaOfInterest>, IEventInAreaOfInterestRepository
    {
        public EventInAreaOfInterestRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}