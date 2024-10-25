using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalonSystem.Models.Skills;

namespace SalonSystem.Data.Repositories 
{
    public class SkillRepository : ISkillRepository 
    {
        private readonly SalonSystemDbContext  _context;
        public SkillRepository(SalonSystemDbContext context) => _context = context;
        
        public async Task<IEnumerable<Skill>> GetAllSkillsAsync() 
        {
            return await _context.Skills.ToListAsync();
        }

        public async Task<Skill>GetSkillByIdAsync(int skillId) 
        {
            return await _context.Skills.FindAsync(skillId);
        }

        public async Task<Skill> AddSkillAsync(Skill skill)
        {
            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();
            return skill;
        }
        
        public async Task<Skill> UpdateSkillAsync(Skill skill) 
        {
            _context.Entry(skill).State = EntityState.Modified;
            await   _context.SaveChangesAsync();
            return skill;
        }
        public async Task<bool> DeleteSkillAsync(int skillId) 
        {
            var techncian = await _context.Skills.FindAsync(skillId);
            if (techncian == null ) return false;

            _context.Skills.Remove(techncian);
            await _context.SaveChangesAsync();
            return true;
        }

    }   
}
