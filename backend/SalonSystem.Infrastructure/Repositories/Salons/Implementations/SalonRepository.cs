using Microsoft.EntityFrameworkCore;
using SalonSystem.Domain.Entities.Salons;
using SalonSystem.Infrastructure.Data;
using SalonSystem.Infrastructure.Repositories.Salons.Interfaces;
using SalonSystem.Infrastructure.Repositories.Base.Implementations;

namespace SalonSystem.Infrastructure.Repositories.Salons.Implementations
{
    public class SalonRepository : GenericRepository<Salon>, ISalonRepository
    {
        private readonly SalonSystemDbContext _context;

        public SalonRepository(SalonSystemDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Salon?> GetSalonWithDetailsAsync(int salonId)
        {
            return await _context.Salons
                .Include(s => s.Services)
                .Include(s => s.Technicians)
                    .ThenInclude(t => t.TechnicianSkills)
                .Include(s => s.SalonSchedules)
                .Include(s => s.DayCloses)
                .FirstOrDefaultAsync(s => s.SalonId == salonId);
        }

        public async Task<IEnumerable<Salon>> GetAllSalonsByOwnerIdAsync(int ownerId)
        {
            return await _context.Salons
                .Where(s => s.OwnerId == ownerId)
                .ToListAsync();
        }
    }
}
