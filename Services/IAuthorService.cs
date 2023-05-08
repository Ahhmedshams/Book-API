using Book_API.Models;

namespace Book_API.Services
{
    public interface IAuthorService
    {
        Task<Author> Add(Author category);
        Task<Author> Delete(int id);
        Task<Author> Edit(int id, Author category);
        Task<List<Author>> GetAll();
        Task<Author> GetById(int id);



    }
}
