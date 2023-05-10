using Book_API.Interfaces;
using Book_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Book_API.Services
{
    public class CRUDRepository<T> : ICRUD<T> where T : class
    {
        private readonly BookifyContextDb context;
        public CRUDRepository(BookifyContextDb _context) {
            context=_context;
        }
        public async Task<List<T>> GetAll(params Expression<Func<T, object>>[] includes)
        {
            if (includes.Length > 0)
            {
                var query = context.Set<T>().AsQueryable();

                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
                return await query.ToListAsync();
            }
            return await context.Set<T>().ToListAsync();
        }
        public async Task<T> GetById(int id, params Expression<Func<T, object>>[] includes)
        {
            if (includes.Length > 0)
            {
                var query = context.Set<T>().AsQueryable();

                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
                return await query.FirstOrDefaultAsync(d => EF.Property<int>(d, "Id") == id);
            }
            return await context.Set<T>().FindAsync(id);
        }
        public async Task<T> Add(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task<T> Delete(int id)
        {
            var foundEntity = await context.Set<T>().FindAsync(id);
            if (foundEntity == null) return null;

            context.Set<T>().Remove(foundEntity);
            await context.SaveChangesAsync();

            return foundEntity;
        }
        public async Task<T> Edit(int id, T entity)
        {
            var foundEntity = await context.Set<T>().FindAsync(id);
            if (foundEntity == null) return null;

            context.Entry(foundEntity).CurrentValues.SetValues(entity);
            await context.SaveChangesAsync();

            return foundEntity;
        }
    }
}
