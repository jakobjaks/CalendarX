using System;
using System.Collections.Generic;
using Domain.Identity;
using AppUser = DAL.App.DTO.Identity.AppUser;

namespace DAL.App.DTO
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
        public string ImageSrc { get; set; }
        public DateTime EventDate { get; set; }


        public bool Equals(Event other)
        {
            if (other is null) return false;
            return this.Id == other.Id;
        }
    }

    public class EventComparer : IEqualityComparer<Event>
    {
        public bool Equals(Event x, Event y)
        {
            //Check whether the compared objects reference the same data.
            if (object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
                return false;

            //Check whether the products' properties are equal.
            return x.Id == y.Id && x.Name == y.Name;
        }

        public int GetHashCode(Event obj)
        {
            //Get hash code for the Name field if it is not null.
            var hashProductName = obj.Name == null ? 0 : obj.Name.GetHashCode();

            //Get hash code for the Code field.
            var hashProductCode = obj.Id.GetHashCode();

            //Calculate the hash code for the product.
            return hashProductName ^ hashProductCode;
        }
    }
}