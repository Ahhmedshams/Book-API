using Book_API.Models;

namespace Book_API.Services
{
    public interface IPurchasable
    {
        Task<PurchasableBook> Add(PurchasableBook book);
        Task<PurchasableBook> Delete(int id);
        Task<PurchasableBook> Edit(int id, PurchasableBook book);
        Task<List<PurchasableBook>> GetAll();
        Task<PurchasableBook> GetById(int id);
    }
}