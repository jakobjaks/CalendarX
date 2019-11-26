using System.Collections;
using System.Collections.Generic;

namespace DAL.App.DTO
{
    public class TargetAudience
    {
        public ICollection<EventTargetAudience> EventsForTargetAudience  { get; set; }
    }
}