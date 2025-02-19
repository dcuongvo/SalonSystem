using Microsoft.EntityFrameworkCore;
using SalonSystem.Domain.Entities.Services;
using SalonSystem.Infrastructure.Data;
using SalonSystem.Infrastructure.Repositories.Services.Interfaces;
using SalonSystem.Infrastructure.Repositories.Base.Implementations;

namespace SalonSystem.Infrastructure.Repositories.Services.Implementations
{
    public class SkillRepository : GenericRepository<Skill>, ISkillRepository
    {
        private readonly SalonSystemDbContext _context;

        public SkillRepository(SalonSystemDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Skill>> GetSkillsBySalonIdAsync(int salonId)
        {
            return await _context.Skills
                .Where(skill => skill.SalonId == salonId)
                .ToListAsync();
        }
    }
}
