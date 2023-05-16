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
    public class SubTypeController : ControllerBase
    {
        private readonly ISubType subType;
        public SubTypeController(ISubType _subType)
        {
            this.subType = _subType;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var types = await subType.GetAllAsync();
            if (!types.Any()) return NotFound("Not Found");

            return Ok(types);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var type = await subType.GetByIdAsync(id);
            if (type == null) return NotFound("Not Found");
            return Ok(type);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var type = await subType.DeleteAsync(id);
            if (type == null) return NotFound("Not Found");
            return Ok(type);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SubTypeDTO Suptype)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var sub = await subType.AddAsync(Suptype.ToASubscriptionType());
            return Ok(sub);

        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Edit(int id,SubscriptionType Suptype)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var sub = await subType.EditAsync(id,Suptype,e=>e.Id);
            return Ok(sub);
        }
    }
}
