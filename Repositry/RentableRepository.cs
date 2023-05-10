using Book_API.Interfaces;
using Book_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace Book_API.Services
{
    public class RentableRepository : CRUDRepository<RentableBook>
    {
        public RentableRepository(BookifyContextDb context) : base(context) { }

        public Task<List<RentableBook>> GetAll() =>
            base.GetAll(e=>e.Author,e=>e.Categories);

        public Task<RentableBook> GetById(int id) =>
            base.GetById(id, e => e.Author, e => e.Categories);
    }
}
