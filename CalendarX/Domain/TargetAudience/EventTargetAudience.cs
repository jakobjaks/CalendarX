namespace Domain
{
    public class EventTargetAudience : DomainEntity
    {

        public int EventId { get; set; }
        public Event Event { get; set; }

        public int TargetAudienceId { get; set; }
        public TargetAudience TargetAudience { get; set; }
        
    }
}