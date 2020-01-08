using System.Collections.Generic;
using Domain.Identity;
using AppUser = DAL.App.DTO.Identity.AppUser;

namespace DAL.App.DTO
{
    public class Organization
    {
        
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        
        public ICollection<OrganizationOrganizing> EventsOrganized { get; set; }
        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}