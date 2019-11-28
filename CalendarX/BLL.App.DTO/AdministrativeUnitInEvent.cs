
namespace BLL.App.DTO
{
    public class AdministrativeUnitInEvent
    {
        public int Id { get; set; }

        public int AdministrativeUnitId { get; set; }
        public AdministrativeUnit AdministrativeUnit { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}