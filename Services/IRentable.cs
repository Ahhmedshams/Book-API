using Book_API.Models;

namespace Book_API.Services
{
    public interface IRentable
    {
        Task<RentableBook> Add(RentableBook book);
        Task<RentableBook> Delete(int id);
        Task<RentableBook> Edit(int id, RentableBook book);
        Task<List<RentableBook>> GetAll();
        Task<RentableBook> GetById(int id);
    }
}