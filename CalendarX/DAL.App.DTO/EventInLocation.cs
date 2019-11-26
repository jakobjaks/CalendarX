namespace DAL.App.DTO
{
    public class EventInLocation
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
        
    }
}