using Microsoft.EntityFrameworkCore;
using SalonSystem.Domain.Entities.Salons;
using SalonSystem.Infrastructure.Repositories.Salons.Interfaces;
using SalonSystem.Infrastructure.Repositories.Base.Implementations;

namespace SalonSystem.Infrastructure.Repositories.Salons.Implementations
{
    public class DayCloseRepository : GenericRepository<DayClose>, IDayCloseRepository
    {
        private readonly DbContext _context;

        public DayCloseRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> IsSalonClosedOnDateAsync(int salonId, DateTime date)
        {
            return await _context.Set<DayClose>()
                .AnyAsync(dc => dc.SalonId == salonId && dc.Date.Date == date.Date);
        }

        public async Task<IEnumerable<DayClose>> GetBySalonIdAsync(int salonId)
        {
            return await _context.Set<DayClose>()
                .Where(dc => dc.SalonId == salonId)
                .ToListAsync();
        }
    }
}
