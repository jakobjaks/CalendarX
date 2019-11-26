using System.Collections;
using System.Collections.Generic;

namespace DAL.App.DTO
{
    public class EventType
    {
        public ICollection<EventInType> EventsInType { get; set; }
    }
}