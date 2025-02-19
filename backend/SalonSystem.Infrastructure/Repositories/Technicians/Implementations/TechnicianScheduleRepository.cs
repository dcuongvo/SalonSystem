using Microsoft.EntityFrameworkCore;
using SalonSystem.Domain.Entities.Technicians;
using SalonSystem.Infrastructure.Data;
using SalonSystem.Infrastructure.Repositories.Technicians.Interfaces;
using SalonSystem.Infrastructure.Repositories.Base.Implementations;

namespace SalonSystem.Infrastructure.Repositories.Technicians.Implementations
{
    public class TechnicianScheduleRepository : GenericRepository<TechnicianSchedule>, ITechnicianScheduleRepository
    {
        private readonly SalonSystemDbContext _context;

        public TechnicianScheduleRepository(SalonSystemDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TechnicianSchedule>> GetSchedulesByTechnicianIdAsync(int technicianId)
        {
            return await _context.TechnicianSchedules
                .Where(ts => ts.TechnicianId == technicianId)
                .Include(ts => ts.TimeBlocks)
                .ToListAsync();
        }

        public async Task<TechnicianSchedule?> GetScheduleByTechnicianAndDayAsync(int technicianId, DayOfWeek day)
        {
            return await _context.TechnicianSchedules
                .Include(ts => ts.TimeBlocks)
                .FirstOrDefaultAsync(ts => ts.TechnicianId == technicianId && ts.Day == day);
        }
    }
}
