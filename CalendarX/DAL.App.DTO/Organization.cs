using System.Collections.Generic;
using Domain.Identity;
using AppUser = DAL.App.DTO.Identity.AppUser;

namespace DAL.App.DTO
{
    public class Organization
    {
        public ICollection<OrganizationOrganizing> EventsOrganized { get; set; }
        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}