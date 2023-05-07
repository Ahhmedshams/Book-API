namespace Book_API.Services
{
    public interface ICategories
    {
        Task<Category> Add(Category category);
        Task<Category> Delete(int id);
        Task<Category> Edit(int id, Category category);
        Task<List<Category>> GetAll();
        Task<Category> GetById(int id);
    }
}