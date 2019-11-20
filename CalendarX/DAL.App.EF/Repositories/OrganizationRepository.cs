using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class OrganizationRepository : BaseRepositoryAsync<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}