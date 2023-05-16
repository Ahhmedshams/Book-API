using Book.Application.Common.Interfaces;
using Book.Domain.Entity;

namespace Book.Infrastructure.Persistence.Repositry
{
    public class PurchasableRepository : CRUDRepository<PurchasableBook> , IPurchasable
    {
        public PurchasableRepository(BookifyContextDb context):base(context) { }

        public Task<List<PurchasableBook>> GetAllAsync() =>
            base.GetAllAsync(e=>e.Author,e=>e.Categories);

        public Task<PurchasableBook> GetByIdAsync(int id) =>
            base.GetByIdAsync(id, e => e.Author, e => e.Categories);
    }
}
