using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class PerformerRepository :
            BaseRepository<DAL.App.DTO.Performer, Domain.Performer, AppDbContext>,
            IPerformerRepository
    {
        public PerformerRepository(AppDbContext repositoryDbContext)
            : base(repositoryDbContext, new PerformerMapper())
        {
        }
    }
}