using Book.Application.Common.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

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

            ResponseMessage<List<ApplicationUserDTO>> responseMessage = new()
            {
                Data = users,
                Status = Status.Success
            };
            return Ok(responseMessage);
        }


        [HttpGet("{Id:Guid}")]
        public async Task<IActionResult> GetById(string id)
        {
            var user = await applicationUser.GetByIdAsync(id);
            if (user == null) return NotFound();

            ResponseMessage<ApplicationUserDTO> responseMessage = new()
            {
                Data = user.ToApplicationUserDTO(),
                Status = Status.Success
            };
            return Ok(responseMessage);
        }





    }
}
