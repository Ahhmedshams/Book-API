using Book_API.Models;

namespace Book_API.Services
{
    public interface ICategory
    {
        Task<Category> Add(Category category);
        Task<Category> Delete(int id);
        Task<Category> Edit(int id, Category category);
        Task<List<Category>> GetAll();
        Task<Category> GetById(int id);
    }
}