using System.Collections.Generic;

namespace Domain
{
    public class AdministrativeUnit : NameDescDomainEntity
    {
        public ICollection<AdministrativeUnitInEvent> EventsInAdministrativeUnit { get; set; }
        
    }
}