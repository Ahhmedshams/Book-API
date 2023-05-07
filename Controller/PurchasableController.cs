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
    public class PurchasableController : ControllerBase
    {
        private readonly IPurchasable purchasableBooksService;
        public PurchasableController(IPurchasable _purchasableBooksService)
        {
            purchasableBooksService = _purchasableBooksService;
        }
        [HttpGet]
        public async Task<ActionResult<List<PurchasableBookDTO>>> GetBooks()
        {
            List<PurchasableBook> books = await purchasableBooksService.GetAll();
            if (books.Count == 0) return NotFound();
            List<PurchasableBookDTO> booksDTOs = new();
            foreach (PurchasableBook book in books)
                booksDTOs.Add(book.ToPurchasableBookDTO());
            return Ok(booksDTOs);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PurchasableBookDTO>> GetBookById(int id)
        {
            PurchasableBook book = await purchasableBooksService.GetById(id);
            if (book == null) return NotFound();
            return Ok(book.ToPurchasableBookDTO());
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PurchasableBookDTO>> DeleteBookById(int id)
        {
            PurchasableBook book = await purchasableBooksService.Delete(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<PurchasableBookDTO>> AddBook(PurchasableBook book)
        {
            await purchasableBooksService.Add(book);
            return CreatedAtAction("GetBookById", book.Id, book);
        }
    }
}
