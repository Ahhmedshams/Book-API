using System.Linq.Expressions;

namespace Book.Application.Common.Interfaces
{
    public interface ICRUD<T> where T : class
    {
        Task<T> AddAsync(T entry);
        Task<T> DeleteAsync(int id);
        Task<T> EditAsync<O>(O id, T entity, Expression<Func<T, O>> keySelector);
        Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync<O>(O id, params Expression<Func<T, object>>[] includes);
    }
}
