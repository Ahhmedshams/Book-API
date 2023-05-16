
namespace Book.Application.Common.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
        bool IsDeleted { get; set; }
        DateTime TimeCreated { get; set; }
        DateTime TimeModified { get; set; }
        ApplicationUser CreatedBy { get; set; }
        ApplicationUser LastModifiedBy { get; set; }
    }
}