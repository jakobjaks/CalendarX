using DAL.App.DTO;

namespace DAL.App.DTO
{
    public class AdministrativeUnitInEvent
    {
        
        public int AdministrativeUnitId { get; set; }
        public AdministrativeUnit AdministrativeUnit { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}