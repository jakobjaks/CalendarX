namespace Domain
{
    public class AdministrativeUnitInEvent : DomainEntity
    {
        
        public int AdministrativeUnitId { get; set; }
        public AdministrativeUnit AdministrativeUnit { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}