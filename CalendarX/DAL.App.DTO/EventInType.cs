namespace DAL.App.DTO
{
    public class EventInType
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int EventTypeId { get; set; }
        public EventType EventType { get; set; }
    }
}