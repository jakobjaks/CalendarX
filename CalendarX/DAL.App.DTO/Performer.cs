using System.Collections.Generic;

namespace DAL.App.DTO
{
    public class Performer
    {
        public ICollection<PerformerInEvent> Type { get; set; }
    }
}