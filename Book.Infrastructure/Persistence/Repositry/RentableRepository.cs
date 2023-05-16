using Book.Application.Common.Interfaces;
using Book.Domain.Entity;


namespace Book.Infrastructure.Persistence.Repositry
{
    public class RentableRepository : CRUDRepository<RentableBook> , IRentable
    {
        public RentableRepository(BookifyContextDb context) : base(context) { }

        public Task<List<RentableBook>> GetAllAsync() =>
            base.GetAllAsync(e=>e.Author,e=>e.Categories);

        public Task<RentableBook> GetByIdAsync(int id) =>
            base.GetByIdAsync(id, e => e.Author, e => e.Categories);
    }
}
