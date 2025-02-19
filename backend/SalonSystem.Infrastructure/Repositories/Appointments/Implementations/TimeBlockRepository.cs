using Microsoft.EntityFrameworkCore;
using SalonSystem.Domain.Entities.Appointments;
using SalonSystem.Infrastructure.Data;
using SalonSystem.Infrastructure.Repositories.Appointments.Interfaces;
using SalonSystem.Infrastructure.Repositories.Base.Implementations;

namespace SalonSystem.Infrastructure.Repositories.Appointments.Implementations
{
    public class TimeBlockRepository : GenericRepository<TimeBlock>, ITimeBlockRepository
    {
        private readonly SalonSystemDbContext _context;

        public TimeBlockRepository(SalonSystemDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TimeBlock>> GetByTechnicianScheduleIdAsync(int scheduleId)
        {
            return await _context.TimeBlocks
                .Where(tb => tb.TechnicianScheduleId == scheduleId)
                .ToListAsync();
        }

        public async Task<IEnumerable<TimeBlock>> GetAvailableBlocksAsync(int scheduleId, DateTime startTime, DateTime endTime)
        {
            return await _context.TimeBlocks
                .Where(tb => tb.TechnicianScheduleId == scheduleId
                             && tb.BlockTime >= startTime
                             && tb.BlockTime < endTime
                             && tb.IsAvailable)
                .ToListAsync();
        }

        public async Task MarkAsOccupiedAsync(int timeBlockId, int appointmentId)
        {
            var timeBlock = await _context.TimeBlocks.FindAsync(timeBlockId);
            if (timeBlock != null)
            {
                timeBlock.IsAvailable = false;
                timeBlock.AppointmentId = appointmentId;
                _context.TimeBlocks.Update(timeBlock);
                await _context.SaveChangesAsync();
            }
        }
    }
}
