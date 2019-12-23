using PublicApi.v1.DTO.Identity;

namespace PublicApi.v1.DTO
{
    public class EventType
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}