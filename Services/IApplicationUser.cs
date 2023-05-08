using Book_API.DTO;
using Book_API.Models;

namespace Book_API.Services
{
    public interface IApplicationUser
    {
        Task<ApplicationUserDTO> EditAsync(int id, ApplicationUser user);
        Task<List<ApplicationUserDTO>> GetAllAsync();
        Task<ApplicationUserDTO> GetByIdAsync(string id);
    }
}
