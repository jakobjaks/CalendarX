using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class AdministrativeUnitInEventRepository : BaseRepositoryAsync<AdministrativeUnitInEvent>, IAdministrativeUnitInEventRepository
    {
        public AdministrativeUnitInEventRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}