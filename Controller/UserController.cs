using Book_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IApplicationUser applicationUser;
        public UserController(IApplicationUser _applicationUser)
        {
            this.applicationUser = _applicationUser;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await applicationUser.GetAllAsync();
            if (!users.Any()) return NotFound("Not Found");
            return Ok(users);
        }


        [HttpGet("{Id:Guid}")]
        public async Task<IActionResult> GetById(string id)
        {
            var user = await applicationUser.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }





    }
}
