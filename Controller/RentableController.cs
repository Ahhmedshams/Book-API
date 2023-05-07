using Book_API.DTO;
using Book_API.Models;
using Book_API.Services;
using Book_API.Utilites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentableController : ControllerBase
    {
        private readonly IRentable rentableService;

        public RentableController(IRentable rentableService)
        {
            this.rentableService = rentableService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RentableBookDTO>>> GetBooks()
        {
            List<RentableBook> books = await rentableService.GetAll();
            if (books.Count == 0) return NotFound();
            List<RentableBookDTO> booksDTOs = new();
            foreach (RentableBook book in books)
                booksDTOs.Add(book.ToRentableBookDTO());
            return Ok(booksDTOs);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<RentableBookDTO>> GetBookById(int id)
        {
            RentableBook book = await rentableService.GetById(id);
            if (book == null) return NotFound();
            return Ok(book.ToRentableBookDTO());
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<RentableBook>> DeleteBookById(int id)
        {
            RentableBook book = await rentableService.Delete(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<RentableBookDTO>> AddBook(RentableBook book)
        {
            await rentableService.Add(book);
            return CreatedAtAction("GetBookById", book.Id, book);
        }
    }
}
