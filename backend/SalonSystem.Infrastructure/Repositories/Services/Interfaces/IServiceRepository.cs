using SalonSystem.Domain.Entities.Services;
using SalonSystem.Infrastructure.Repositories.Base.Interfaces;

namespace SalonSystem.Infrastructure.Repositories.Services.Interfaces
{
    public interface IServiceRepository : IRepository<Service>
    {
        Task<IEnumerable<Service>> GetServicesBySalonIdAsync(int salonId);
        Task<Service?> GetServiceWithSkillsAsync(int serviceId);
    }
}
    