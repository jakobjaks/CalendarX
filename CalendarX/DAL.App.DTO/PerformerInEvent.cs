namespace DAL.App.DTO
{
    public class PerformerInEvent
    {
        
        
        public int PerformerId { get; set; }
        public Performer Performer { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }

        public string Description { get; set; }
        public string Name { get; set; }
    }
}