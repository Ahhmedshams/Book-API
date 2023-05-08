using Book_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Book_API.Services
{
    public class AuthorsService: IAuthorService
    {
        private readonly BookifyContextDb context;

        public AuthorsService(BookifyContextDb _context) {
            context=_context;
        }



        public async Task<Author> Add(Author author)
        {
            context.Authors.Add(author);
            await context.SaveChangesAsync();

            return author;
        }

        public async Task<Author> Delete(int id)
        {
            Author author = context.Authors.FirstOrDefault(author => author.Id == id);

            if (author == null)
            {
                return null;
            }
            context.Authors.Remove(author);
            await context.SaveChangesAsync();

            return author;
        }

        public async Task<Author> Edit(int id, Author author)
        {
            Author founded = context.Authors.FirstOrDefault(author => author.Id == id);

            if (founded == null) return null;

            context.Entry(author).State = EntityState.Modified;


            await context.SaveChangesAsync();

            return author;
        }

        public Task<List<Author>> GetAll()
        {
            return context.Authors.ToListAsync();
        }

        public async Task<Author> GetById(int id)
        {
            return await context.Authors.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
