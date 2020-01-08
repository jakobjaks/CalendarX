using System.Collections;
using System.Collections.Generic;

namespace DAL.App.DTO
{
    public class TargetAudience
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        
        public ICollection<EventTargetAudience> EventsForTargetAudience  { get; set; }
    }
}