using Book_API.DTO;
using Book_API.Models;

namespace Book_API.Services
{
    public interface ISubscribable
    {
        Task<Subscriber> AddAsync(SubscriberDTO sub);
        Task<Subscriber> DeleteAsync(int id);
        Task<Subscriber> EditAsync(int id, Subscriber sub);
        Task<List<Subscriber>> GetAllAsync();
        Task<Subscriber> GetByIdAsync(int id);
    }
}
