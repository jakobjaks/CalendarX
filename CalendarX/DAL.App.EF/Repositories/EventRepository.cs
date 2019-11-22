using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public override async Task<IEnumerable<Event>> AllAsync()
        {
            return await RepositoryDbSet.Include(c => c.EventLocations).ToListAsync();
        }
    }
}