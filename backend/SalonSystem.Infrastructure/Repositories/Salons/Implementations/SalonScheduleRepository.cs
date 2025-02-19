using Microsoft.EntityFrameworkCore;
using SalonSystem.Domain.Entities.Salons;
using SalonSystem.Infrastructure.Data;
using SalonSystem.Infrastructure.Repositories.Salons.Interfaces;
using SalonSystem.Infrastructure.Repositories.Base.Implementations;

namespace SalonSystem.Infrastructure.Repositories.Salons.Implementations
{
    public class SalonScheduleRepository : GenericRepository<SalonSchedule>, ISalonScheduleRepository
    {
        private readonly SalonSystemDbContext _context;

        public SalonScheduleRepository(SalonSystemDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SalonSchedule>> GetSchedulesBySalonIdAsync(int salonId)
        {
            return await _context.SalonSchedules
                .Where(ss => ss.SalonId == salonId)
                .ToListAsync();
        }

        public async Task<bool> IsSalonOpenAsync(int salonId, DateTime dateTime)
        {
            // Check if the salon is closed on the given date
            var isDayClosed = await _context.DayCloses
                .AnyAsync(dc => dc.SalonId == salonId && dc.Date.Date == dateTime.Date);

            if (isDayClosed)
                return false;

            // Get the salon's schedule for the given day of the week
            var salonSchedule = await _context.SalonSchedules
                .FirstOrDefaultAsync(ss => ss.SalonId == salonId && ss.Day == dateTime.DayOfWeek);

            if (salonSchedule == null)
                return false;

            // Check if the current time is within the operating hours
            var timeOfDay = dateTime.TimeOfDay;
            return timeOfDay >= salonSchedule.OpenTime && timeOfDay <= salonSchedule.CloseTime;
        }
    }
}
