using Book.Application.Common.Interfaces;

using Book.Infrastructure.Persistence.Repositry;
using Book.Domain.Entity;
using Book.Infrastructure;

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
