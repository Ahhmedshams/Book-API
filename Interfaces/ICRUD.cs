using Book_API.Models;
using System.Linq.Expressions;

namespace Book_API.Interfaces
{
    public interface ICRUD<T> where T : class 
    {
        Task<T> Add(T entry);
        Task<T> Delete(int id);
        Task<T> Edit(int id, T entry);
        Task<List<T>> GetAll(params Expression<Func<T, object>>[] includes);
        Task<T> GetById(int id, params Expression<Func<T, object>>[] includes);
    }
}
