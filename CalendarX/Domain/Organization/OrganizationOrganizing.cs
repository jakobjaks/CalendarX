namespace Domain
{
    public class OrganizationOrganizing : DomainEntity
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}