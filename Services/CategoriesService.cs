using Book_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_API.Services
{
    public class CategoriesService
    {
        private BookifyContextDb context;

        public CategoriesService(BookifyContextDb context)
        {
            this.context = context;
        }

        public Task<List<Category>> GetAll() =>
            context.Categories.Include("Books").ToListAsync();

        public Task<Category> GetById(int id) =>
            context.Categories.Include("Books").FirstOrDefaultAsync(e=>e.Id==id);

        public async Task<Category> Edit(int id, Category category)
        {
            Category foundCategory = await context.Categories.Include("Books").FirstOrDefaultAsync(e => e.Id == id);
            if (foundCategory == null) return null;
            foundCategory.Name = category.Name;
            foundCategory.Books= category.Books;
            await context.SaveChangesAsync();
            return foundCategory;
        }
    
        public async Task<Category> Delete(int id)
        {
            Category foundCategory = await context.Categories.FirstOrDefaultAsync(e => e.Id == id);
            if (foundCategory == null) return null;
            context.Categories.Remove(foundCategory);
            await context.SaveChangesAsync();
            return foundCategory; 
        }
    
        public async Task<Category> Add(Category category)
        {
            context.Categories.Add(category);
            await context.SaveChangesAsync();
            return category;
        }
    }
}
