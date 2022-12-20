using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using core.Interfaces;
using infrastructure.Database.StoreContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace infrastructure.Database.Generic
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }

        public async void AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> FindOneAsync(Expression<Func<T, bool>> filterExpression)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(filterExpression);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filterExpression, List<Expression<Func<T, object>>> includeExpression)
        {
            var result = _context.Set<T>().AsQueryable();

            result = result.Where(filterExpression);

            foreach(var include in includeExpression)
            {
                result = result.Include(include);
            }

            return  await result.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<bool> isExitAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AnyAsync(expression);
        }

        public void UpdateAsync(T entity)
        {
            // EntityEntry entityEntry = _context.Entry<T>(entity);
            // entityEntry.State = EntityState.Modified;
            _context.Set<T>().Update(entity);
        }

        void IRepository<T>.RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}