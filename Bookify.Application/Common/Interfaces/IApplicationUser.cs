namespace Book.Application.Common.Interfaces
{
    public interface IApplicationUser
    {
        Task<ApplicationUser> EditAsync(string id, ApplicationUser user);
        Task<List<ApplicationUserDTO>> GetAllAsync();
        Task<ApplicationUser> GetByIdAsync(string id);
    }
}
