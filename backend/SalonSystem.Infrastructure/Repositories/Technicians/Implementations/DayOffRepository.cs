using Microsoft.EntityFrameworkCore;
using SalonSystem.Domain.Entities.Technicians;
using SalonSystem.Infrastructure.Repositories.Technicians.Interfaces;
using SalonSystem.Infrastructure.Repositories.Base.Implementations;

namespace SalonSystem.Infrastructure.Repositories.Technicians.Implementations
{
    public class DayOffRepository : GenericRepository<DayOff>, IDayOffRepository
    {
        private readonly DbContext _context;

        public DayOffRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DayOff>> GetByTechnicianIdAsync(int technicianId)
        {
            return await _context.Set<DayOff>()
                .Where(d => d.TechnicianId == technicianId)
                .ToListAsync();
        }

        public async Task<bool> IsTechnicianOffAsync(int technicianId, DateTime date)
        {
            return await _context.Set<DayOff>()
                .AnyAsync(d => d.TechnicianId == technicianId && d.Date.Date == date.Date);
        }
    }
}
