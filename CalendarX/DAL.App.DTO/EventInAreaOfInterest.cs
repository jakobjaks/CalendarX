using DAL.App.DTO;

namespace DAL.App.DTO
{
    public class EventInAreaOfInterest
    {

        public int EventId { get; set; }
        public Event Event { get; set; }

        public int AreaOfInterestId { get; set; }
        public AreaOfInterest AreaOfInterest { get; set; }
    }
}