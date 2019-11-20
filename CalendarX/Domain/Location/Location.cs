using System.Collections.Generic;

namespace Domain
{
    public class Location : NameDescDomainEntity
    {

        public ICollection<EventInLocation> EventsInLocation { get; set; }
    }
}