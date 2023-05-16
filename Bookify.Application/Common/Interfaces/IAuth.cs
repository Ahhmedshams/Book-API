
namespace Book.Application.Common.Interfaces
{
    public interface IAuth
    {
        Task<AuthModel> RegisterAsync(RegisterUserDTO model);
        Task<AuthModel> GetTokenAsync(LoginDTO model);
        Task<string> AddRoleAsync(AddRoleDTO model);
    }
}
