using Book_API.Interfaces;
using Book_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_API.Services
{
    public class CategoryRepository : CRUDRepository<Category>,ICategory
    {
        public CategoryRepository(BookifyContextDb context) : base(context) { }

        public Task<List<Category>> GetAllAsync() =>
            base.GetAllAsync(e=>e.Books);

        public Task<Category> GetByIdAsync(int id) =>
            base.GetByIdAsync(id, e => e.Books);
    }
}
