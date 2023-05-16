
using Book.Application.Common.Interfaces;
using Book.Domain.Entity;
using Book.Infrastructure;
using Book.Infrastructure.Persistence.Repositry;

namespace Book_API.Repositry
{
    public class SubTypeRepository : CRUDRepository<SubscriptionType>, ISubType
    {
        public SubTypeRepository(BookifyContextDb _context) : base(_context)
        {
        }



        public Task<List<SubscriptionType>> GetAllAsync() =>
        base.GetAllAsync(e => e.subscribers);

        public Task<SubscriptionType> GetByIdAsync(int id) =>
            base.GetByIdAsync(id, e => e.subscribers);
    }
}
