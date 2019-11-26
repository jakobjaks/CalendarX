using System;
using Domain.Identity;

namespace BLL.App.DTO
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        
        public string? PictureUrl { get; set; }
        
        public int? SubEventId { get; set; }
        public virtual Event SubEvent { get; set; }

        public int? NextEventId { get; set; }
        public virtual Event NextEvent { get; set; }
        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}