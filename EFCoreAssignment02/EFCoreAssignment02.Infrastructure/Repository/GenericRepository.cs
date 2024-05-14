using EFCoreAssignment02.WebApp.Database;
using EFCoreAssignment02.WebApp.Interfaces;
using EFCoreAssignment02.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace EFCoreAssignment02.WebApp.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<T> AddEntity(T entity)
        {
            await _context.Set<T>().AddAsync(entity);  
            await SaveChanges();
            return entity;
        }

        public async Task DeleteEntity(T entity)
        {
            _context.Set<T>().Remove(entity);
            await SaveChanges();
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<T> UpdateEntity(T entity)
        {
            _context.Set<T>().Update(entity);
            await SaveChanges();
            return entity;
        }
        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
        public async Task<bool> IsExist(Guid id)
        {
            if( await GetById(id) == null) return false;
            return true;
        }

        public IQueryable<T> GetAllQueryable()
        {
            return _context.Set<T>();
        }
    }
}
