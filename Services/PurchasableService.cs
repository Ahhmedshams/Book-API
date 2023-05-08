using Book_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace Book_API.Services
{
    public class OrderService 
    {
        private BookifyContextDb context;

        public OrderService(BookifyContextDb context)
        {
            this.context = context;
        }

        //public Task<List<Order>> GetAll() =>
        //    context.PurchasableBooks.Include("User").ToListAsync();

        public Task<PurchasableBook> GetById(int id) =>
            context.PurchasableBooks.Include("User").FirstOrDefaultAsync(e => e.Id == id);

        public async Task<PurchasableBook> Edit(int id, PurchasableBook book)
        {
            PurchasableBook foundBook = await context.PurchasableBooks.Include("Author").Include("Categories").FirstOrDefaultAsync(e => e.Id == id);
            if (foundBook == null) return null;
            foundBook.Title= book.Title;
            foundBook.NumberOfPages= book.NumberOfPages;
            foundBook.Image= book.Image;
            foundBook.AuthorId = book.AuthorId;
            foundBook.Categories= book.Categories;

            foundBook.Quantity= book.Quantity;
            foundBook.Price= book.Price;
            await context.SaveChangesAsync();
            return foundBook;
        }

        public async Task<PurchasableBook> Delete(int id)
        {
            PurchasableBook foundBook = await context.PurchasableBooks.FirstOrDefaultAsync(e => e.Id == id);
            if (foundBook == null) return null;
            context.PurchasableBooks.Remove(foundBook);
            await context.SaveChangesAsync();
            return foundBook;
        }
        
        public async Task<PurchasableBook> Add(PurchasableBook book)
        {
            context.PurchasableBooks.Add(book);
            await context.SaveChangesAsync();
            return book;
        }
    }
}
