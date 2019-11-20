using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class EventType : NameDescDomainEntity
    {
        public ICollection<EventInType> EventsInType { get; set; }
    }
}