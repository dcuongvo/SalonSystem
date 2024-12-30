using SalonSystem.Domain.Entities.Services;
using SalonSystem.Infrastructure.Repositories.Base.Interfaces;


namespace SalonSystem.Infrastructure.Repositories.Services.Interfaces
{
    public interface IServiceRepository : IRepository<Service>
    {
        Task<IEnumerable<Service>> GetBySalonIdAsync(int salonId);

        Task<Service?> GetByNameAsync(int salonId, string serviceName);
    }
}
