using Book_API.DTO;
using Book_API.Helpers;
using Book_API.Interfaces;
using Book_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasableController : ControllerBase
    {
        private readonly IPurchasable purchasableService;
        public PurchasableController(IPurchasable _purchasableService)
        {
            purchasableService = _purchasableService;
        }
        [HttpGet]
        public async Task<ActionResult<List<PurchasableBookDTO>>> GetBooks()
        {
            List<PurchasableBook> books = await purchasableService.GetAll();
            if (books.Count == 0) return NotFound();
            List<PurchasableBookDTO> booksDTOs = new();
            foreach (PurchasableBook book in books)
                booksDTOs.Add(book.ToPurchasableBookDTO());
            return Ok(booksDTOs);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PurchasableBookDTO>> GetBookById(int id)
        {
            PurchasableBook book = await purchasableService.GetById(id);
            if (book == null) return NotFound();
            return Ok(book.ToPurchasableBookDTO());
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PurchasableBook>> DeleteBookById(int id)
        {
            PurchasableBook book = await purchasableService.Delete(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<PurchasableBookDTO>> AddBook(PurchasableBook book)
        {
            await purchasableService.Add(book);
            return CreatedAtAction("GetBookById", book.Id, book);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<PurchasableBookDTO>> EditBook(int id,PurchasableBook book)
        {
            PurchasableBook editedBook = await purchasableService.Edit(id, book);
            if(editedBook == null) return NotFound();
            return Ok(editedBook.ToPurchasableBookDTO());
        }
    }
}
