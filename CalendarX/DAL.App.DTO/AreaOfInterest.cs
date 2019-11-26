using System.Collections.Generic;

namespace DAL.App.DTO
{
    public class AreaOfInterest
    {
        public ICollection<EventInAreaOfInterest> EventsInAreaOfInterest { get; set; }
    }
}