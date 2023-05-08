using Book_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_API.Services
{
    public class OrderService : IOrder
    {
        private BookifyContextDb context;

        public OrderService(BookifyContextDb context)
        {
            this.context = context;
        }

        public Task<List<Order>> GetAll() =>
            context.Orders.Include("User").Include("Items").ToListAsync();

        public Task<Order> GetById(int id) =>
            context.Orders.Include("User").Include("Items").FirstOrDefaultAsync(e => e.Id == id);

        public async Task<Order> Edit(int id, Order order)
        {
            Order foundOrder = await context.Orders.Include("User").Include("Items").FirstOrDefaultAsync(e => e.Id == id);
            if (foundOrder == null) return null;
            foreach (OrderItem item in order.Items)
                context.OrderItems.Update(item);
            await context.SaveChangesAsync();
            return foundOrder;
        }

        public async Task<Order> Delete(int id)
        {
            Order foundBook = await context.Orders.FirstOrDefaultAsync(e => e.Id == id);
            if (foundBook == null) return null;
            context.Orders.Remove(foundBook);
            await context.SaveChangesAsync();
            return foundBook;
        }

        public async Task<Order> Add(Order order)
        {
            context.Orders.Add(order);
            foreach (OrderItem item in order.Items)
                context.OrderItems.Add(item);
            await context.SaveChangesAsync();
            return order;
        }
    }
}
