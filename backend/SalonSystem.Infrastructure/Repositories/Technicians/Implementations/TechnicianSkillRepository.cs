using Microsoft.EntityFrameworkCore;
using SalonSystem.Domain.Entities.Technicians;
using SalonSystem.Infrastructure.Data;
using SalonSystem.Infrastructure.Repositories.Technicians.Interfaces;
using SalonSystem.Infrastructure.Repositories.Base.Implementations;

namespace SalonSystem.Infrastructure.Repositories.Technicians.Implementations
{
    public class TechnicianSkillRepository : GenericRepository<TechnicianSkill>, ITechnicianSkillRepository
    {
        private readonly SalonSystemDbContext _context;

        public TechnicianSkillRepository(SalonSystemDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TechnicianSkill>> GetSkillsByTechnicianIdAsync(int technicianId)
        {
            return await _context.TechnicianSkills
                .Where(ts => ts.TechnicianId == technicianId)
                .Include(ts => ts.Skill)
                .ToListAsync();
        }
    }
}
