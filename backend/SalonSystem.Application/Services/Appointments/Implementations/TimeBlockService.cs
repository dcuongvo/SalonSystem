using SalonSystem.Application.Services.Appointments.Interfaces;
using SalonSystem.Domain.Entities.Appointments;
using SalonSystem.Infrastructure.Repositories.Appointments.Interfaces;
using SalonSystem.Application.Services.Base.Implementations;

namespace SalonSystem.Application.Services.Appointments.Implementations
{
    public class TimeBlockService : GenericService<TimeBlock>, ITimeBlockService
    {
        private readonly ITimeBlockRepository _timeBlockRepository;

        public TimeBlockService(ITimeBlockRepository timeBlockRepository) : base(timeBlockRepository)
        {
            _timeBlockRepository = timeBlockRepository;
        }

        public async Task<IEnumerable<TimeBlock>> GetAvailableBlocksAsync(int scheduleId, DateTime startTime, DateTime endTime)
        {
            return await _timeBlockRepository.GetAvailableBlocksAsync(scheduleId, startTime, endTime);
        }

        public async Task MarkAsOccupiedAsync(int timeBlockId, int appointmentId)
        {
            await _timeBlockRepository.MarkAsOccupiedAsync(timeBlockId, appointmentId);
        }

        public async Task<IEnumerable<TimeBlock>> GetByTechnicianScheduleIdAsync(int scheduleId)
        {
            return await _timeBlockRepository.GetByTechnicianScheduleIdAsync(scheduleId);
        }
    }
}
