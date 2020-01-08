using BLL.App.DTO.Identity;

namespace BLL.App.DTO
{
    public class Organization
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}