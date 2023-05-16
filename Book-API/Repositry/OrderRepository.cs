using Book_API.Interfaces;
using Book_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Book_API.Services
{
    public class OrderRepository : CRUDRepository<Order> , IOrder
    {
        public OrderRepository(BookifyContextDb context) : base(context) { }

        public Task<List<Order>> GetAllAsync() =>
            base.GetAllAsync(e => e.User);

        public Task<Order> GetByIdAsync(int id) =>
           base.GetByIdAsync(id, e => e.User);
    }
}


