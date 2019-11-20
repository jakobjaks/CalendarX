using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class EventTargetAudienceRepository : BaseRepositoryAsync<EventTargetAudience>, IEventTargetAudienceRepository
    {
        public EventTargetAudienceRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}