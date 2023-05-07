using Book_API.DTO;
using Book_API.Models;
using Book_API.Utilites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Book_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AccountController ( UserManager<ApplicationUser > userManager, IConfiguration configuration )
        {
            _userManager = userManager;
            _configuration = configuration;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserDTO userDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            //Create new user 

            ApplicationUser userModel = userDTO.ToApplicationUser();

            IdentityResult result = await _userManager.CreateAsync(userModel, userDTO.Password);

            if (result.Succeeded)
            {
                return Ok("Create Succes");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
               
            }

            return BadRequest(ModelState);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login (LoginDTO userDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            ApplicationUser userModel = await _userManager.FindByEmailAsync(userDTO.Email);

            if(userModel!= null && await _userManager.CheckPasswordAsync(userModel, userDTO.Password)) 
            {

                //Create Claims
                List<Claim> userClaims = await  CreateUserClaims(userModel);

                JwtSecurityToken userToken = CreateToken(userClaims);

                return Ok( new {
                                token = new JwtSecurityTokenHandler().WriteToken(userToken),
                                expiration = userToken.ValidTo
                                });
            }
           return BadRequest("Invalid Login Account");
        }


        private async Task< List<Claim>> CreateUserClaims (ApplicationUser userModel)
        {
            List<Claim> userClaims = new();
            userClaims.Add(new Claim("FirstName", userModel.FirstName));
            userClaims.Add(new Claim("LastName", userModel.LastName));
            userClaims.Add(new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            userClaims.Add(new Claim(ClaimTypes.NameIdentifier, userModel.Id));

            List<string> roles = (List<string>)await _userManager.GetRolesAsync(userModel);
            if (roles != null)
            {
                foreach (string role in roles)
                {
                    userClaims.Add(new Claim(ClaimTypes.Role, role));
                }
            }


            return userClaims;
        }

        private JwtSecurityToken CreateToken(List<Claim> userClaims)
        {
            string KeyAsString = _configuration["JWT:SecritKey"];
            byte[] KeyAsByte = Encoding.UTF8.GetBytes(KeyAsString);

            var authSecret = new SymmetricSecurityKey(KeyAsByte);
            SigningCredentials credentials = new SigningCredentials(authSecret, SecurityAlgorithms.HmacSha256); //key , Alg

            //Create Token
            JwtSecurityToken userToken = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIss"],
                audience: _configuration["JWT:ValidAdu"],
                expires: DateTime.Now.AddHours(2),
                claims: userClaims,
                signingCredentials: credentials
                );

            return userToken;
        }
    }
}
