namespace DAL.App.DTO
{
    public class EventTargetAudience
    {

        public int EventId { get; set; }
        public Event Event { get; set; }

        public int TargetAudienceId { get; set; }
        public TargetAudience TargetAudience { get; set; }
        
    }
}