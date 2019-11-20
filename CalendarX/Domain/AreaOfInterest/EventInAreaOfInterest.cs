namespace Domain
{
    public class EventInAreaOfInterest : DomainEntity
    {

        public int EventId { get; set; }
        public Event Event { get; set; }

        public int AreaOfInterestId { get; set; }
        public AreaOfInterest AreaOfInterest { get; set; }
    }
}