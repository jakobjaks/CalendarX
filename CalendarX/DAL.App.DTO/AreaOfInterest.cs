using System.Collections.Generic;

namespace DAL.App.DTO
{
    public class AreaOfInterest
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        
        public ICollection<EventInAreaOfInterest> EventsInAreaOfInterest { get; set; }
    }
}