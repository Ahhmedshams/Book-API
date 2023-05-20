using Book.Application.Common.DTO;
using Book.Application.Common.Model;
using Microsoft.AspNetCore.Mvc;

namespace Book_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {

        private ISubscribable subscriberService;
        private IApplicationUser user;
        public SubscriberController(ISubscribable subscriberService, IApplicationUser _user)
        {
            this.subscriberService = subscriberService;
            this.user = _user;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var subscribers = await subscriberService.GetAllAsync();
            if (!subscribers.Any()) return NotFound("Not Found");

            List<SubscriberResponseDTO> subscribersDTO = new List<SubscriberResponseDTO>();
            foreach (var subscriber in subscribers)
            {
                subscribersDTO.Add(subscriber.ToSubResponse());
            }

            ResponseMessage<List<SubscriberResponseDTO>> responseMessage = new() { 
                Data = subscribersDTO,
                Status = Status.Success
            };
            return Ok(responseMessage);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var subscriber = await subscriberService.GetByIdAsync(id);
            if (subscriber == null) return NotFound("Not Found");

            ResponseMessage<SubscriberResponseDTO> responseMessage = new()
            {
                Data = subscriber.ToSubResponse(),
                Status = Status.Success
            };
            return Ok(responseMessage);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var subscriber = await subscriberService.DeleteAsync(id);
            if (subscriber == null) return NotFound("Not Found");
            ResponseMessage<SubscriberResponseDTO> responseMessage = new()
            {
                Data = subscriber.ToSubResponse(),
                Status = Status.Success
            };
            return Ok(responseMessage);
        }

        [HttpPost]
        public async Task<IActionResult> AddSubscriber(SubscriberDTO subscriber)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var AppUser = await user.GetByIdAsync(subscriber.UserId);
            if (AppUser == null) return NotFound(Errors.InvalidUserId);

            AppUser.IsSubscriber = true;
            var userUpdate = await  user.EditAsync(AppUser.Id, AppUser);
            var sub = await subscriberService.AddAsync(subscriber.ToSubscriber());

            ResponseMessage<SubscriberResponseDTO> responseMessage = new()
            {
                Data = sub.ToSubResponse(),
                Status = Status.Success
            };
            return Ok(responseMessage);

        }


    }
}
