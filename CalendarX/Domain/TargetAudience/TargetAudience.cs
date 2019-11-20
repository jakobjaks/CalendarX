using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class TargetAudience : NameDescDomainEntity
    {
        public ICollection<EventTargetAudience> EventsForTargetAudience  { get; set; }
    }
}