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

        [HttpGet("Id:string")]
        public async Task<IActionResult> GetById(string id)
        {
            var user = await applicationUser.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }


    }
}
