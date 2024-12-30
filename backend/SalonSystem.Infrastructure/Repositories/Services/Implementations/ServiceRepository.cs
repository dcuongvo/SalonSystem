using Microsoft.EntityFrameworkCore;
using SalonSystem.Domain.Entities.Services;
using SalonSystem.Infrastructure.Repositories.Services.Interfaces;
using SalonSystem.Infrastructure.Repositories.Base.Implementations;

namespace SalonSystem.Infrastructure.Repositories.Services.Implementations
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        private readonly DbContext _context;

        public ServiceRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        // Get services by salon ID
        public async Task<IEnumerable<Service>> GetBySalonIdAsync(int salonId)
        {
            return await _context.Set<Service>()
                .Where(s => s.SalonId == salonId)
                .Include(s => s.ServiceSkills)
                .ThenInclude(ss => ss.Skill)
                .ToListAsync();
        }

        // Get a service by its name in a specific salon
        public async Task<Service?> GetByNameAsync(int salonId, string serviceName)
        {
            return await _context.Set<Service>()
                .FirstOrDefaultAsync(s => s.SalonId == salonId && s.ServiceName == serviceName);
        }
    }
}
