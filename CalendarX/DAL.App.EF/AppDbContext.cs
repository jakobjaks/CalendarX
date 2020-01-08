using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    // Force identity db context to use our AppUser and AppRole - with int as PK type
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DbSet<AdministrativeUnit> AdministrativeUnits { get; set; }
        public DbSet<AdministrativeUnitInEvent> AdministrativeUnitInEvents { get; set; }
        public DbSet<AreaOfInterest> AreaOfInterests { get; set; }
        public DbSet<EventInAreaOfInterest> EventInAreaOfInterests { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventInType> EventInTypes { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventInLocation> EventInLocations { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationOrganizing> OrganizationOrganizings { get; set; }
        public DbSet<SponsorInEvent> SponsorInEvents  { get; set; }
        public DbSet<Performer> Performers  { get; set; }
        public DbSet<PerformerInEvent> PerformerInEvents { get; set; }
        public DbSet<EventTargetAudience> EventTargetAudiences { get; set; }
        public DbSet<TargetAudience> TargetAudiences { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // disable cascade delete
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Cascade;
            }
            
            
            
        }

    }
}