using Book_API.Interfaces;
using Book_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace Book_API.Services
{
    public class PurchasableRepository : CRUDRepository<PurchasableBook>
    {
        public PurchasableRepository(BookifyContextDb context):base(context) { }

        public Task<List<PurchasableBook>> GetAll() =>
            base.GetAll(e=>e.Author,e=>e.Categories);

        public Task<PurchasableBook> GetById(int id) =>
            base.GetById(id, e => e.Author, e => e.Categories);
    }
}
