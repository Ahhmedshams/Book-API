using AutoMapper;
using Book_API.DTO;
using Book_API.Interfaces;
using Book_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAuthor authorsService;

        public AuthorController(IMapper mapper, IAuthor authorsService) {
            this.mapper=mapper;
            this.authorsService=authorsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            List<Author> authors = await authorsService.GetAllAsync();

            List<AuthorDTO> authorsDTO = mapper.Map<List<AuthorDTO>>(authors);

            return Ok(authorsDTO);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            if (id == 0)
                return BadRequest();

            Author author = await authorsService.GetByIdAsync(id);

            if (author == null)
                return NotFound();

            return Ok(author);

        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorDTO authorDTO)
        {
            if (ModelState.IsValid)
            {
                Author authror = mapper.Map<Author>(authorDTO);
                Author author = await authorsService.AddAsync(authror);
                return CreatedAtAction("GetAuthorById", new {Id = authror.Id}, author);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> Update(AuthorDTO authorDTO)
        {

            if (authorDTO.Id == 0)
                return BadRequest();

            if (ModelState.IsValid)
            {
                Author author = mapper.Map<Author>(authorDTO);
                Author updated = await authorsService.EditAsync(author.Id, author);
                return NoContent();
            }

            return BadRequest(ModelState);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            await authorsService.DeleteAsync(id);
            return NoContent();
        }

    }
}
