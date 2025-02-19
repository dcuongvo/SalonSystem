using SalonSystem.Domain.Entities.Technicians;
using SalonSystem.Infrastructure.Repositories.Base.Interfaces;

namespace SalonSystem.Infrastructure.Repositories.Technicians.Interfaces
{
    public interface IDayOffRepository : IRepository<DayOff>
    {
        Task<IEnumerable<DayOff>> GetDaysOffByTechnicianIdAsync(int technicianId);
        Task<bool> IsDayOffAsync(int technicianId, DateTime date);
    }
}
