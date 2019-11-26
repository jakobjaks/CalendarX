using Domain.Identity;

namespace BLL.App.DTO
{
    public class AdministrativeUnit
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        
        public string? PictureUrl { get; set; }
        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}