using Book_API.DTO;
using Book_API.Helpers;
using Book_API.Interfaces;
using Book_API.Models;
using Book_API.Services;

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
