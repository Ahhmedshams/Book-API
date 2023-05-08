using Book_API.Models;

namespace Book_API.Services
{
    public interface IOrder
    {
        Task<Order> Add(Order order);
        Task<Order> Delete(int id);
        Task<List<Order>> GetAll();
        Task<Order> GetById(int id);
    }
}