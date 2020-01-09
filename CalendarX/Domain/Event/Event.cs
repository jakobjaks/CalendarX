using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Identity;

namespace Domain
{
    public class Event : NameDescDomainEntity
    {

        public string? PictureUrl { get; set; }

        public ICollection<EventInAreaOfInterest> EventAreasOfInterest { get; set; }

        public ICollection<EventInLocation> EventLocations { get; set; }

        public ICollection<EventInType> EventTypes { get; set; }

        public ICollection<OrganizationOrganizing> EventOrganizers { get; set; }

        public ICollection<SponsorInEvent> EventSponsors { get; set; }

        public ICollection<PerformerInEvent> EventPerformers { get; set; }

        public ICollection<AdministrativeUnitInEvent> EventAdministrativeUnit { get; set; }

        [ForeignKey("SubEvent")]
        public int? SubEventId { get; set; }
        public virtual Event SubEvent { get; set; }

        [ForeignKey("NextEvent")]
        public int? NextEventId { get; set; }
        public virtual Event NextEvent { get; set; }
        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public string ImageSrc { get; set; }
        public DateTime EventDate { get; set; }

    }
}