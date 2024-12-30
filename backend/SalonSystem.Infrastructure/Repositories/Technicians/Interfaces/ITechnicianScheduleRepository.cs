using SalonSystem.Domain.Entities.Technicians;
using SalonSystem.Infrastructure.Repositories.Base.Interfaces;

namespace SalonSystem.Infrastructure.Repositories.Technicians.Interfaces
{
    public interface ITechnicianScheduleRepository : IRepository<TechnicianSchedule>
    {
        Task<IEnumerable<TechnicianSchedule>> GetSchedulesByTechnicianIdAsync(int technicianId);

        Task<TechnicianSchedule?> GetScheduleByTechnicianAndDayAsync(int technicianId, DayOfWeek day);
    }
}
