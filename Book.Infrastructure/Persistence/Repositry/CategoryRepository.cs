using Book.Application.Common.Interfaces;
using Book.Domain.Entity;

namespace Book.Infrastructure.Persistence.Repositry
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
