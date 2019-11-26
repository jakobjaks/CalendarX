using System.Collections.Generic;
using Domain.Identity;

namespace Domain
{
    public class AdministrativeUnit : NameDescDomainEntity
    {
        public ICollection<AdministrativeUnitInEvent> EventsInAdministrativeUnit { get; set; }
        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}