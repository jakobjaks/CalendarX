using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;

namespace DAL.App.EF.Repositories
{
    public class TargetAudienceRepository : BaseRepository<DAL.App.DTO.TargetAudience, Domain.TargetAudience, AppDbContext>,
        ITargetAudienceRepository
    {
        public TargetAudienceRepository(AppDbContext repositoryDbContext)
            : base(repositoryDbContext, new TargetAudienceMapper())
        {
        }
    }
}