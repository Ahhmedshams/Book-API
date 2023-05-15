
using Book_API.DTO;
using Book_API.Models;

namespace Book_API.Interfaces
{
    public interface IAuth
    {
        Task<AuthModel> RegisterAsync(RegisterUserDTO model);
        Task<AuthModel> GetTokenAsync(LoginDTO model);
        Task<string> AddRoleAsync(AddRoleDTO model);
    }
}
