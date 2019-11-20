using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class AdministrativeUnitRepository : BaseRepositoryAsync<AdministrativeUnit>, IAdministrativeUnitRepository
    {
        public AdministrativeUnitRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}