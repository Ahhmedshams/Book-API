﻿using Book.Application.Common.Model;
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
            List<PurchasableBook> books = await purchasableService.GetAllAsync();
            if (books.Count == 0) return NotFound();
            List<PurchasableBookDTO> booksDTOs = new();
            foreach (PurchasableBook book in books)
                booksDTOs.Add(book.ToPurchasableBookDTO());
            return Ok(booksDTOs);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PurchasableBookDTO>> GetBookById(int id)
        {
            PurchasableBook book = await purchasableService.GetByIdAsync(id);
            if (book == null) return NotFound();
            return Ok(book.ToPurchasableBookDTO());
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PurchasableBook>> DeleteBookById(int id)
        {
            PurchasableBook book = await purchasableService.DeleteAsync(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<PurchasableBookDTO>> AddBook(PurchasableBook book)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            PurchasableBook addedBook = await purchasableService.AddAsync(book);
            return Ok(addedBook.ToPurchasableBookDTO());
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<PurchasableBookDTO>> EditBook(int id, PurchasableBook book)
        {
            PurchasableBook editedBook = await purchasableService.EditAsync(id, book, e => e.Id);
            if (editedBook == null) return NotFound();
            return Ok(editedBook.ToPurchasableBookDTO());
        }
    }
}
