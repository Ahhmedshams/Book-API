using Book_API.DTO;
using Book_API.Models;

namespace Book_API.Services
{
    public interface IApplicationUser
    {
        Task<ApplicationUserDTO> Edit(int id, ApplicationUser user);
        Task<List<ApplicationUserDTO>> GetAll();
        Task<ApplicationUserDTO> GetById(string id);
    }
}
