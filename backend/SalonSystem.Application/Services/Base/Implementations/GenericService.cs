using System.Collections.Generic;
using System.Threading.Tasks;
using SalonSystem.Application.Services.Base.Interfaces;
using SalonSystem.Infrastructure.Repositories.Base.Interfaces;

namespace SalonSystem.Application.Services.Base.Implementations
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public GenericService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
