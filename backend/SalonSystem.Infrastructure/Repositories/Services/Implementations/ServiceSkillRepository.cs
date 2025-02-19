using Microsoft.EntityFrameworkCore;
using SalonSystem.Domain.Entities.Services;
using SalonSystem.Infrastructure.Data;
using SalonSystem.Infrastructure.Repositories.Services.Interfaces;
using SalonSystem.Infrastructure.Repositories.Base.Implementations;

namespace SalonSystem.Infrastructure.Repositories.Services.Implementations
{
    public class ServiceSkillRepository : GenericRepository<ServiceSkill>, IServiceSkillRepository
    {
        private readonly SalonSystemDbContext _context;

        public ServiceSkillRepository(SalonSystemDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceSkill>> GetServiceSkillsByServiceIdAsync(int serviceId)
        {
            return await _context.ServiceSkills
                .Where(ss => ss.ServiceId == serviceId)
                .Include(ss => ss.Skill)
                .ToListAsync();
        }
    }
}
