using Book_API.Interfaces;

namespace Book_API.Models
{
    public class Entity : IEntity
    {
        public int Id { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeModified { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        public ApplicationUser LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
