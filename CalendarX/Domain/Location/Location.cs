using System.Collections.Generic;
using Domain.Identity;

namespace Domain
{
    public class Location : NameDescDomainEntity
    {

        public ICollection<EventInLocation> EventsInLocation { get; set; }
        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}