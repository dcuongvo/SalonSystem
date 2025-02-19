using Microsoft.EntityFrameworkCore;
using SalonSystem.Domain.Entities.Salons;
using SalonSystem.Infrastructure.Data;
using SalonSystem.Infrastructure.Repositories.Salons.Interfaces;
using SalonSystem.Infrastructure.Repositories.Base.Implementations;

namespace SalonSystem.Infrastructure.Repositories.Salons.Implementations
{
    public class DayCloseRepository : GenericRepository<DayClose>, IDayCloseRepository
    {
        private readonly SalonSystemDbContext _context;

        public DayCloseRepository(SalonSystemDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DayClose>> GetDayClosesBySalonIdAsync(int salonId)
        {
            return await _context.DayCloses
                .Where(dc => dc.SalonId == salonId)
                .ToListAsync();
        }
    }
}
