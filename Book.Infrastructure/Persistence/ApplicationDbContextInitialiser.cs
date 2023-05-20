using Book.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Infrastructure.Persistence
{
    public class ApplicationDbContextInitialiser
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly BookifyContextDb _bookifyContextDb;

        public ApplicationDbContextInitialiser(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, BookifyContextDb bookifyContextDb)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _bookifyContextDb = bookifyContextDb;
        }


        public async Task InitialiseAsync()
        {
            try
            {
                if (_bookifyContextDb.Database.IsSqlServer())
                    await _bookifyContextDb.Database.MigrateAsync();
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task SeedAsync() 
        { 
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task TrySeedAsync()
        {
            //Add Admin Role
            var AdminRole = new IdentityRole("Admin");
            if(_roleManager.Roles.Any(role=> role.Name != AdminRole.Name)) await _roleManager.CreateAsync(AdminRole);

            //Add User Role
            var UserRole = new IdentityRole("User");
            if (_roleManager.Roles.Any(role => role.Name != UserRole.Name)) await _roleManager.CreateAsync(UserRole);
            
            // System Admin
            var Admin = new ApplicationUser { UserName = "admin", Email = "admin@example.com" ,FirstName= "Ahmed" ,LastName = "Shams"};

            if (_userManager.Users.All(u => u.UserName != Admin.UserName))
            {
                await _userManager.CreateAsync(Admin, "Admin@123!");
                await _userManager.AddToRolesAsync(Admin, new[] { AdminRole.Name });
            }

            await _bookifyContextDb.SaveChangesAsync();
        }
    }
}
