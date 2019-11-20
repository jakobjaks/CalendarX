using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Event : NameDescDomainEntity
    {

        public ICollection<EventInAreaOfInterest> EventAreasOfInterest { get; set; }

        public ICollection<EventInLocation> EventLocations { get; set; }

        public ICollection<EventInType> EventTypes { get; set; }

        public ICollection<OrganizationOrganizing> EventOrganizers { get; set; }

        public ICollection<SponsorInEvent> EventSponsors { get; set; }

        public ICollection<PerformerInEvent> EventPerformers { get; set; }

        public ICollection<AdministrativeUnitInEvent> EventAdministrativeUnit { get; set; }

        [ForeignKey("SubEvent")]
        public int SubEventId { get; set; }
        public Event SubEvent { get; set; }

        [ForeignKey("NextEvent")]
        public int NextEventId { get; set; }
        public Event NextEvent { get; set; }

    }
}