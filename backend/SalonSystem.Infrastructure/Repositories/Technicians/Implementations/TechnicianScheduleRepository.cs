using Microsoft.EntityFrameworkCore;
using SalonSystem.Domain.Entities.Technicians;
using SalonSystem.Infrastructure.Repositories.Technicians.Interfaces;
using SalonSystem.Infrastructure.Repositories.Base.Implementations;

namespace SalonSystem.Infrastructure.Repositories.Technicians.Implementations
{
    public class TechnicianScheduleRepository : GenericRepository<TechnicianSchedule>, ITechnicianScheduleRepository
    {
        private readonly DbContext _context;

        public TechnicianScheduleRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TechnicianSchedule>> GetSchedulesByTechnicianIdAsync(int technicianId)
        {
            return await _context.Set<TechnicianSchedule>()
                .Where(ts => ts.TechnicianId == technicianId)
                .Include(ts => ts.TimeBlocks) // Include TimeBlocks if relevant
                .ToListAsync();
        }

        public async Task<TechnicianSchedule?> GetScheduleByTechnicianAndDayAsync(int technicianId, DayOfWeek day)
        {
            return await _context.Set<TechnicianSchedule>()
                .Include(ts => ts.TimeBlocks)
                .FirstOrDefaultAsync(ts => ts.TechnicianId == technicianId && ts.Day == day);
        }
    }
}
