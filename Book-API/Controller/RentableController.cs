﻿using Book.Application.Common.Model;
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
            List<RentableBook> books = await rentableService.GetAllAsync();
            if (books.Count == 0) return NotFound();
            List<RentableBookDTO> booksDTOs = new();
            foreach (RentableBook book in books)
                booksDTOs.Add(book.ToRentableBookDTO());
            return Ok(booksDTOs);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<RentableBookDTO>> GetBookById(int id)
        {
            RentableBook book = await rentableService.GetByIdAsync(id);
            if (book == null) return NotFound();
            return Ok(book.ToRentableBookDTO());
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<RentableBook>> DeleteBookById(int id)
        {
            RentableBook book = await rentableService.DeleteAsync(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<RentableBookDTO>> AddBook(RentableBook book)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            RentableBook addedBook = await rentableService.AddAsync(book);
            return Ok(addedBook.ToRentableBookDTO());
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<RentableBookDTO>> EditBook(int id, RentableBook book)
        {
            RentableBook editedBook = await rentableService.EditAsync(id, book,e=>e.Id);
            if (editedBook == null) return NotFound();
            return Ok(editedBook.ToRentableBookDTO());
        }
    }
}
