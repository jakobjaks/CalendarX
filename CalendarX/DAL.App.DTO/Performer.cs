using System.Collections.Generic;

namespace DAL.App.DTO
{
    public class Performer
    {
        
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        
        public ICollection<PerformerInEvent> Type { get; set; }
    }
}