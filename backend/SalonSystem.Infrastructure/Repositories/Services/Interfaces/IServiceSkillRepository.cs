using SalonSystem.Domain.Entities.Services;
using SalonSystem.Infrastructure.Repositories.Base.Interfaces;

namespace SalonSystem.Infrastructure.Repositories.Services.Interfaces
{
    public interface IServiceSkillRepository : IRepository<ServiceSkill>
    {
        Task<IEnumerable<ServiceSkill>> GetServiceSkillsByServiceIdAsync(int serviceId);
    }
}
