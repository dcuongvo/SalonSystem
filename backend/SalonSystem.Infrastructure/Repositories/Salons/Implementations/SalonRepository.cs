using Microsoft.EntityFrameworkCore;
using SalonSystem.Infrastructure.Repositories.Salons.Interfaces;
using SalonSystem.Domain.Entities.Salons;
using SalonSystem.Infrastructure.Repositories.Base.Implementations;

namespace SalonSystem.Infrastructure.Repositories.Salons.Implementations
{
    public class SalonRepository : GenericRepository<Salon>, ISalonRepository
    {
        private readonly DbContext _context;

        public SalonRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Salon>> GetByOwnerIdAsync(int ownerId)
        {
            return await _context.Set<Salon>()
                .Include(s => s.Technicians)
                .Include(s => s.Services)
                .Where(s => s.OwnerId == ownerId)
                .ToListAsync();
        }

        public async Task<Salon?> GetSalonDetailsAsync(int salonId)
        {
            return await _context.Set<Salon>()
                .Include(s => s.Technicians)
                .Include(s => s.Services)
                .Include(s => s.SalonSchedules)
                .Include(s => s.DayCloses)
                .FirstOrDefaultAsync(s => s.SalonId == salonId);
        }
    }
}
