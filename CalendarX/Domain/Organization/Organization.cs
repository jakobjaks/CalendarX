using System.Collections.Generic;
using Domain.Identity;

namespace Domain
{
    public class Organization : NameDescDomainEntity
    {
        public ICollection<OrganizationOrganizing> EventsOrganized { get; set; }
        public ICollection<SponsorInEvent> EventsSponsored { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}