using Book.Application.Common.DTO;
using Book.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Book.Application.Common.Helpers;
using Book.Application.Common.Interfaces;

namespace Book.Infrastructure.Persistence.Repositry
{
    public class ApplicationUserRepository: IApplicationUser
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return null;

            return user;
        }

        public async Task<ApplicationUser> EditAsync(string id, ApplicationUser Appuser)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return null;
            var reselt = await _userManager.UpdateAsync(Appuser);
            if (reselt.Succeeded) return Appuser;
            else return null;
        }

        public async Task<List<ApplicationUserDTO>> GetAllAsync()
        {
            var user = await _userManager.Users.ToListAsync();
            if (user.Count == 0) return null;
            List<ApplicationUserDTO> users = new();
            foreach (var item in user)
            {
                users.Add(item.ToApplicationUserDTO());
            }

            return users;
        }
    }
}
