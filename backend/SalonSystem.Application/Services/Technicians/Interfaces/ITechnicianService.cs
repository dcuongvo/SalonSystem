using SalonSystem.Domain.Entities.Technicians;
using SalonSystem.Application.Services.Base.Interfaces;

namespace SalonSystem.Application.Services.Technicians.Interfaces
{
    public interface ITechnicianService : IGenericService<Technician>
    {
        Task<IEnumerable<Technician>> GetTechniciansBySalonIdAsync(int salonId);
        Task<bool> IsTechnicianAvailableAsync(int technicianId, DateTime dateTime, TimeSpan duration);
        Task<TechnicianSchedule?> GetScheduleByTechnicianAndDayAsync(int technicianId, DayOfWeek day);
        Task<IEnumerable<TechnicianSkill>> GetSkillsByTechnicianIdAsync(int technicianId);
    }
}
