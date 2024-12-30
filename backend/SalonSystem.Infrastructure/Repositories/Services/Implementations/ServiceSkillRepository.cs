using Microsoft.EntityFrameworkCore;
using SalonSystem.Domain.Entities.Services;
using SalonSystem.Infrastructure.Repositories.Base.Implementations;
using SalonSystem.Infrastructure.Repositories.Services.Interfaces;

namespace SalonSystem.Infrastructure.Repositories.Services.Implementations
{
    public class ServiceSkillRepository : GenericRepository<ServiceSkill>, IServiceSkillRepository
    {
        private readonly DbContext _context;

        public ServiceSkillRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceSkill>> GetByServiceIdAsync(int serviceId)
        {
            return await _context.Set<ServiceSkill>()
                .Where(ss => ss.ServiceId == serviceId)
                .Include(ss => ss.Skill)
                .ToListAsync();
        }
    }
}
