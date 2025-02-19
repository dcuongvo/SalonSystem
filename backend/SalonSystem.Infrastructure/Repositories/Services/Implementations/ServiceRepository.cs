using Microsoft.EntityFrameworkCore;
using SalonSystem.Domain.Entities.Services;
using SalonSystem.Infrastructure.Data;
using SalonSystem.Infrastructure.Repositories.Services.Interfaces;
using SalonSystem.Infrastructure.Repositories.Base.Implementations;

namespace SalonSystem.Infrastructure.Repositories.Services.Implementations
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        private readonly SalonSystemDbContext _context;

        public ServiceRepository(SalonSystemDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetServicesBySalonIdAsync(int salonId)
        {
            return await _context.Services
                .Where(s => s.SalonId == salonId)
                .Include(s => s.ServiceSkills)
                    .ThenInclude(ss => ss.Skill)
                .ToListAsync();
        }

        public async Task<Service?> GetServiceWithSkillsAsync(int serviceId)
        {
            return await _context.Services
                .Include(s => s.ServiceSkills)
                    .ThenInclude(ss => ss.Skill)
                .FirstOrDefaultAsync(s => s.ServiceId == serviceId);
        }
    }
}
