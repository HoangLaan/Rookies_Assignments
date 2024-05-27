using EFCoreAssignment02.WebApp.Models;
using System.Collections.ObjectModel;

namespace EFCoreAssignment02.WebApp.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T?> GetById(Guid id);
        Task DeleteEntity(T entity);
        Task<T> UpdateEntity(T entity);
        Task<T> AddEntity(T entity);
        Task<int> SaveChanges();
        Task<bool> IsExist(Guid id);
        IQueryable<T> GetAllQueryable();
    }
}
