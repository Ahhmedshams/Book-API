using Book_API.Models;
using System.Linq.Expressions;

namespace Book_API.Interfaces
{
    public interface ICRUD<T> where T : class 
    {
        Task<T> AddAsync(T entry);
        Task<T> DeleteAsync(int id);
        Task<T> EditAsync(int id, T entry);
        Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync<O>(O id, params Expression<Func<T, object>>[] includes);
    }
}
