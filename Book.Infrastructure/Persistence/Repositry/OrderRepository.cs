using Book.Application.Common.Interfaces;
using Book.Domain.Entity;

namespace Book.Infrastructure.Persistence.Repositry
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


