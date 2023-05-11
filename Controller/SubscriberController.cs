using Book_API.DTO;
using Book_API.Helpers;
using Book_API.Interfaces;
using Book_API.Models;
using Book_API.Services;
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

            return Ok(subscribersDTO);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var subscriber = await subscriberService.GetByIdAsync(id);
            if (subscriber == null) return NotFound("Not Found");
            return Ok(subscriber.ToSubResponse());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var subscriber = await subscriberService.DeleteAsync(id);
            if (subscriber == null) return NotFound("Not Found");
            return Ok(subscriber.ToSubResponse());
        }

        [HttpPost]
        public async Task<IActionResult> AddSubscriber(SubscriberDTO subscriber)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var AppUser = await user.GetByIdAsync(subscriber.UserId);
            if (AppUser == null) return NotFound("Can Not Found User With this ID");

            var sub = await subscriberService.AddAsync(subscriber.ToSubscriber());
            return Ok(sub);

        }


    }
}
