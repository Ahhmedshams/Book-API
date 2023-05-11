using Book_API.DTO;
using Book_API.Models;

namespace Book_API.Services
{
    public interface IApplicationUser
    {
        Task<ApplicationUser> EditAsync(string id, ApplicationUser user);
        Task<List<ApplicationUserDTO>> GetAllAsync();
        Task<ApplicationUser> GetByIdAsync(string id);
    }
}
