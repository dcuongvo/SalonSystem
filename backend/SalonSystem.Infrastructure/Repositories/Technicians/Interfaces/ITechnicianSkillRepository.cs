using SalonSystem.Domain.Entities.Technicians;
using SalonSystem.Infrastructure.Repositories.Base.Interfaces;

namespace SalonSystem.Infrastructure.Repositories.Technicians.Interfaces
{
    public interface ITechnicianSkillRepository : IRepository<TechnicianSkill>
    {
        Task<IEnumerable<TechnicianSkill>> GetSkillsByTechnicianIdAsync(int technicianId);
    }
}
