using SalonSystem.Domain.Entities.Technicians;
using SalonSystem.Infrastructure.Repositories.Base.Interfaces;

namespace SalonSystem.Infrastructure.Repositories.Technicians.Interfaces
{
    public interface ITechnicianRepository : IRepository<Technician>
    {
        Task<IEnumerable<Technician>> GetBySalonIdAsync(int salonId);
        Task<IEnumerable<Technician>> GetTechniciansWithSkillAsync(int skillId);
    }
}
