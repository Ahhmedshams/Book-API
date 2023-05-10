using Book_API.Interfaces;
using Book_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_API.Services
{
    public class OrderRepositry : CRUDRepository<Order>
    {
        public OrderRepositry(BookifyContextDb context) : base(context) { }

        public Task<List<Order>> GetAll() =>
            base.GetAll(e => e.User);

        public Task<Order> GetById(int id) =>
           base.GetById(id, e => e.User);
    }
}
