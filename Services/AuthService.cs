using Book_API.DTO;
using Book_API.Helpers;
using Book_API.Models;
using Book_API.Utilites;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Book_API.Services
{
    public class AuthService:IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;

        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
        }
        public async Task<AuthModel> RegisterAsync(RegisterUserDTO model)
        {
            if (await _userManager.FindByEmailAsync(model.Email) is not null)
                return new AuthModel { Message = "Email is already registered!" };

            if (await _userManager.FindByNameAsync(model.Username) is not null)
                return new AuthModel { Message = "UserName is already registered!" };


            ApplicationUser user = model.ToApplicationUser();

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            
            if(!result.Succeeded)
            {
                StringBuilder errors = null;
                foreach (var error in result.Errors)
                {
                    errors.Append($"{error.Description},") ;
                }
                return new AuthModel { Message = errors.ToString() };
            }

            await _userManager.AddToRoleAsync(user, "User");

            List<Claim> claims = await CreateUserClaims(user);

            JwtSecurityToken userToken = CreateToken(claims);

            return new AuthModel()
            {
                Email = user.Email,
                ExpiresOn = userToken.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(userToken),
                Username = user.UserName
            };
        }

        public async Task<AuthModel> GetTokenAsync(LoginDTO model)
        {
            AuthModel authModel = new();

            ApplicationUser user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Message = "Email or Password is incorrect!";
                return authModel;
            }

            List<Claim> claims = await CreateUserClaims(user);

            JwtSecurityToken userToken = CreateToken(claims);

            var rolesList = await _userManager.GetRolesAsync(user);

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(userToken);
            authModel.Email = user.Email;
            authModel.Username = user.UserName;
            authModel.ExpiresOn = userToken.ValidTo;
            authModel.Roles = rolesList.ToList();

            return authModel;
        }

        public async Task<string> AddRoleAsync(AddRoleDTO model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null || !await _roleManager.RoleExistsAsync(model.Role))
                return "Invalid user ID or Role";

            if (await _userManager.IsInRoleAsync(user, model.Role))
                return "User already assigned to this role";

            var result = await _userManager.AddToRoleAsync(user, model.Role);

            return result.Succeeded ? string.Empty : "Sonething went wrong";
        }


        private async Task<List<Claim>> CreateUserClaims(ApplicationUser userModel)
        {
            var ExistiedClaims = await _userManager.GetClaimsAsync(userModel);
            var roles = await _userManager.GetRolesAsync(userModel);
            List<Claim> userClaims = new();

            userClaims.Union(ExistiedClaims);

            foreach (var role in roles)
                userClaims.Add(new Claim("roles", role));

            userClaims.Add(new Claim("FirstName", userModel.FirstName));
            userClaims.Add(new Claim("LastName", userModel.LastName));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            userClaims.Add(new Claim(ClaimTypes.NameIdentifier, userModel.Id));

            return userClaims;
        }
        private JwtSecurityToken CreateToken(List<Claim> userClaims)
        {
            
            byte[] KeyAsByte = Encoding.UTF8.GetBytes(_jwt.Key);

            var authSecret = new SymmetricSecurityKey(KeyAsByte);
            SigningCredentials credentials = new SigningCredentials(authSecret, SecurityAlgorithms.HmacSha256); //key , Alg

            //Create Token
            JwtSecurityToken userToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                claims: userClaims,
                signingCredentials: credentials
                );

            return userToken;
        }
        
    }
}

