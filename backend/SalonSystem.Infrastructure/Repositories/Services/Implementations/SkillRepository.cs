using Microsoft.EntityFrameworkCore;
using SalonSystem.Domain.Entities.Services;
using SalonSystem.Infrastructure.Repositories.Base.Implementations;
using SalonSystem.Infrastructure.Repositories.Services.Interfaces;

namespace SalonSystem.Infrastructure.Repositories.Services.Implementations
{
    public class SkillRepository : GenericRepository<Skill>, ISkillRepository
    {
        private readonly DbContext _context;

        public SkillRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Skill>> GetBySalonIdAsync(int salonId)
        {
            return await _context.Set<Skill>()
                .Where(s => s.SalonId == salonId)
                .ToListAsync();
        }

        public async Task<Skill?> GetByNameAsync(int salonId, string skillName)
        {
            return await _context.Set<Skill>()
                .FirstOrDefaultAsync(s => s.SalonId == salonId && s.SkillName == skillName);
        }
    }
}
