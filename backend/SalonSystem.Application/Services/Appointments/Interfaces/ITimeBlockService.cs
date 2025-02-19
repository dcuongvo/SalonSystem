using SalonSystem.Domain.Entities.Appointments;
using SalonSystem.Application.Services.Base.Interfaces;

namespace SalonSystem.Application.Services.Appointments.Interfaces
{
    public interface ITimeBlockService : IGenericService<TimeBlock>
    {
        Task<IEnumerable<TimeBlock>> GetAvailableBlocksAsync(int scheduleId, DateTime startTime, DateTime endTime);
        Task MarkAsOccupiedAsync(int timeBlockId, int appointmentId);
        Task<IEnumerable<TimeBlock>> GetByTechnicianScheduleIdAsync(int scheduleId);
    }
}
