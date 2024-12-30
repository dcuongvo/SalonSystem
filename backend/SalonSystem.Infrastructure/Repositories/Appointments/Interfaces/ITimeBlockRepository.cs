using SalonSystem.Domain.Entities.Appointments;
using SalonSystem.Infrastructure.Repositories.Base.Interfaces;

namespace SalonSystem.Infrastructure.Repositories.Appointments.Interfaces
{
    public interface ITimeBlockRepository : IRepository<TimeBlock>
    {
        Task<IEnumerable<TimeBlock>> GetByTechnicianScheduleIdAsync(int scheduleId);

        Task<IEnumerable<TimeBlock>> GetAvailableBlocksAsync(int scheduleId, DateTime startTime, DateTime endTime);

        Task MarkAsOccupiedAsync(int timeBlockId, int appointmentId);
    }
}
