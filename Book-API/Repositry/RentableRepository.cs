using Book_API.Interfaces;
using Book_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace Book_API.Services
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
