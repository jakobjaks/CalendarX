using System.Collections.Generic;

namespace Domain
{
    public class Performer : NameDescDomainEntity
    {
        public ICollection<PerformerInEvent> Type { get; set; }
    }
}