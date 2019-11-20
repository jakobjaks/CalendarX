using System.Collections.Generic;

namespace Domain
{
    public class Organization : NameDescDomainEntity
    {
        public ICollection<OrganizationOrganizing> EventsOrganized { get; set; }
    }
}