using Microsoft.EntityFrameworkCore;
using SalonSystem.Domain.Entities.Technicians;
using SalonSystem.Infrastructure.Repositories.Technicians.Interfaces;
using SalonSystem.Infrastructure.Repositories.Base.Implementations;

namespace SalonSystem.Infrastructure.Repositories.Technicians.Implementations
{
    public class TechnicianRepository : GenericRepository<Technician>, ITechnicianRepository
    {
        private readonly DbContext _context;

        public TechnicianRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Technician>> GetBySalonIdAsync(int salonId)
        {
            return await _context.Set<Technician>()
                .Where(t => t.SalonId == salonId)
                .Include(t => t.TechnicianSkills)
                .ThenInclude(ts => ts.Skill)
                .ToListAsync();
        }

        public async Task<IEnumerable<Technician>> GetTechniciansWithSkillAsync(int skillId)
        {
            return await _context.Set<Technician>()
                .Where(t => t.TechnicianSkills.Any(ts => ts.SkillId == skillId))
                .ToListAsync();
        }
    }
}
