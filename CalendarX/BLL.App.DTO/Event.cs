using System;
using System.Collections.Generic;
using BLL.App.DTO.Identity;
using Domain;

namespace BLL.App.DTO
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        
        public string? PictureUrl { get; set; }
        
        public int? SubEventId { get; set; }
        public virtual Event SubEvent { get; set; }

        public int? NextEventId { get; set; }
        public virtual Event NextEvent { get; set; }
        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        

        public ICollection<AdministrativeUnit>? AdministrativeUnits { get; set; }
        public ICollection<Location>? Locations { get; set; }
        public ICollection<EventType>? EventTypes { get; set; }


    }
}