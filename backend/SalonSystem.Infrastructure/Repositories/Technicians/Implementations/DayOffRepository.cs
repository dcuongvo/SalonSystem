using Microsoft.EntityFrameworkCore;
using SalonSystem.Domain.Entities.Technicians;
using SalonSystem.Infrastructure.Data;
using SalonSystem.Infrastructure.Repositories.Technicians.Interfaces;
using SalonSystem.Infrastructure.Repositories.Base.Implementations;

namespace SalonSystem.Infrastructure.Repositories.Technicians.Implementations
{
    public class DayOffRepository : GenericRepository<DayOff>, IDayOffRepository
    {
        private readonly SalonSystemDbContext _context;

        public DayOffRepository(SalonSystemDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DayOff>> GetDaysOffByTechnicianIdAsync(int technicianId)
        {
            return await _context.DaysOff
                .Where(doff => doff.TechnicianId == technicianId)
                .ToListAsync();
        }

        public async Task<bool> IsDayOffAsync(int technicianId, DateTime date)
        {
            return await _context.DaysOff
                .AnyAsync(doff => doff.TechnicianId == technicianId && doff.Date.Date == date.Date);
        }
    }
}
