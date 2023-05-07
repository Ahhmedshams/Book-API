using Book_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace Book_API.Services
{
    public class RentableService : IRentable
    {
        private BookifyContextDb context;

        public RentableService(BookifyContextDb context)
        {
            this.context = context;
        }

        public Task<List<RentableBook>> GetAll() =>
            context.RentableBooks.Include("Author").Include("Categories").ToListAsync();

        public Task<RentableBook> GetById(int id) =>
            context.RentableBooks.Include("Author").Include("Categories").FirstOrDefaultAsync(e => e.Id == id);

        public async Task<RentableBook> Edit(int id, RentableBook book)
        {
            RentableBook foundBook = await context.RentableBooks.Include("Author").Include("Categories").FirstOrDefaultAsync(e => e.Id == id);
            if (foundBook == null) return null;
            foundBook.Title= book.Title;
            foundBook.NumberOfPages= book.NumberOfPages;
            foundBook.Image= book.Image;
            foundBook.AuthorId = book.AuthorId;
            foundBook.Categories= book.Categories;

            foundBook.NumberOfCopies= book.NumberOfCopies;
            foundBook.AvailableCopies= book.AvailableCopies;
            await context.SaveChangesAsync();
            return foundBook;
        }

        public async Task<RentableBook> Delete(int id)
        {
            RentableBook foundBook = await context.RentableBooks.FirstOrDefaultAsync(e => e.Id == id);
            if (foundBook == null) return null;
            context.RentableBooks.Remove(foundBook);
            await context.SaveChangesAsync();
            return foundBook;
        }
        
        public async Task<RentableBook> Add(RentableBook book)
        {
            context.RentableBooks.Add(book);
            await context.SaveChangesAsync();
            return book;
        }
    }
}
