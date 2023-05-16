using Book_API.Interfaces;
using Book_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Book_API.Services
{
    public class CRUDRepository<T> : ICRUD<T> where T : class
    {
        protected readonly BookifyContextDb context;
        public CRUDRepository(BookifyContextDb _context) {
            context=_context;
        }
        public async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = context.Set<T>().AsQueryable();
            if (includes.Length > 0)
            {
                foreach (var include in includes)
                         query = query.Include(include);
                  
            }
            return await query.ToListAsync();
        }
        public async Task<T> GetByIdAsync<O> (O id, params Expression<Func<T, object>>[] includes)
        {
            var query = context.Set<T>().AsQueryable();
            if (includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
               // return await query.FirstOrDefaultAsync(d => EF.Property<O>(d, "Id") == id); Need HElp 
            }
            return await context.Set<T>().FindAsync(id);
        }
        public async Task<T> AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task<T> DeleteAsync(int id)
        {
            var foundEntity = await context.Set<T>().FindAsync(id);
            if (foundEntity == null) return null;

            context.Set<T>().Remove(foundEntity);
            await context.SaveChangesAsync();

            return foundEntity;
        }
        public async Task<T> EditAsync<O>(O id, T entity, Expression<Func<T, O>> keySelector)
        {
            var foundEntity = await context.Set<T>().FindAsync(id);
            if (foundEntity == null) return null;
            context.Entry(entity).Property(keySelector).CurrentValue = id;
            context.Entry(foundEntity).CurrentValues.SetValues(entity);
            await context.SaveChangesAsync();
            return foundEntity;
        }

    }
}
