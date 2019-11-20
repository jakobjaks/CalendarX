using System.Collections.Generic;

namespace Domain
{
    public class AreaOfInterest : NameDescDomainEntity
    {
        public ICollection<EventInAreaOfInterest> EventsInAreaOfInterest { get; set; }
    }
}