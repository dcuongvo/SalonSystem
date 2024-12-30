using SalonSystem.Domain.Entities.Technicians;
using SalonSystem.Infrastructure.Repositories.Base.Interfaces;

namespace SalonSystem.Infrastructure.Repositories.Technicians.Interfaces
{
    public interface IDayOffRepository : IRepository<DayOff>
    {
        // Get days off by technician
        Task<IEnumerable<DayOff>> GetByTechnicianIdAsync(int technicianId);

        // Check if a technician is off on a specific date
        Task<bool> IsTechnicianOffAsync(int technicianId, DateTime date);
    }
}
