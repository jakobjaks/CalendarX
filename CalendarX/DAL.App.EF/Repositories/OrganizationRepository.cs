using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class OrganizationRepository :
        BaseRepository<DAL.App.DTO.Organization, Domain.Organization, AppDbContext>,
        IOrganizationRepository
    {
        public OrganizationRepository(AppDbContext repositoryDbContext)
            : base(repositoryDbContext, new OrganizationMapper())
        {
        }
    }
}