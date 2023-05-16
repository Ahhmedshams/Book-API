using Book_API.DTO;
using Book_API.Interfaces;
using Book_API.Models;
using Book_API.Services;
using Microsoft.EntityFrameworkCore;

namespace Book_API.Repositry
{
    public class SubscriberRepository:CRUDRepository<Subscriber> ,ISubscribable
    {

        public SubscriberRepository(BookifyContextDb context) :base(context) { }

        public Task<List<Subscriber>> GetAllAsync() =>
                base.GetAllAsync(e => e.User , e => e.subscriptionType);

        public Task<Subscriber> GetByIdAsync(int id) =>
            base.GetByIdAsync(id, e => e.User, e => e.subscriptionType);

    }
}
