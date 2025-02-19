

namespace SalonSystem.Application.Services.Base.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
