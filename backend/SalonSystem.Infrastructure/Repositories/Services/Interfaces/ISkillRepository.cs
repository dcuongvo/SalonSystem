using SalonSystem.Domain.Entities.Services;
using SalonSystem.Infrastructure.Repositories.Base.Interfaces;

namespace SalonSystem.Infrastructure.Repositories.Services.Interfaces
{
    public interface ISkillRepository : IRepository<Skill>
    {
        Task<IEnumerable<Skill>> GetSkillsBySalonIdAsync(int salonId);
    }
}
