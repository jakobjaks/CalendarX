using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;


namespace DAL.App.EF.Repositories
{
    public class AreaOfInterestRepository :
        BaseRepository<DAL.App.DTO.AreaOfInterest, Domain.AreaOfInterest, AppDbContext>,
        IAreaOfInterestRepository
    {
        public AreaOfInterestRepository(AppDbContext repositoryDbContext)
            : base(repositoryDbContext, new AreaOfInterestMapper())
        {
        }
    }
}