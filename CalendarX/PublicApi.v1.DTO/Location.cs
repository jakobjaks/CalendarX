
using PublicApi.v1.DTO.Identity;

namespace PublicApi.v1.DTO
{
    public class Location
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        
        public string? PictureUrl { get; set; }
        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}