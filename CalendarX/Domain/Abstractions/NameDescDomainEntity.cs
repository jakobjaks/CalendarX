using Contracts.DAL.Base;

namespace Domain
{
    public abstract class NameDescDomainEntity : IBaseEntity
    {
        public int Id { get; set; } // Primary Key for every entity type  

        public string Name { get; set; }

        public string Description { get; set; }
    }
}