using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class AreaOfInterestRepository : BaseRepositoryAsync<AreaOfInterest>, IAreaOfInterestRepository
    {
        public AreaOfInterestRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}