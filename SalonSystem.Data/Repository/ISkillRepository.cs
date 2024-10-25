using System.Collections.Generic;
using System.Threading.Tasks;
using SalonSystem.Models.Skills;

namespace SalonSystem.Data.Repositories 
{
    public interface ISkillRepository 
    {
        Task<IEnumerable<Skill>> GetAllSkillsAsync();
        Task<Skill> GetSkillByIdAsync(int skillId);
        //Task<Skill> GetSkillAsync(Skill skill);
        Task<Skill> AddSkillAsync(Skill skill);
        Task<Skill> UpdateSkillAsync(Skill skill);
        Task<bool> DeleteSkillAsync(int skillId); 
    }   
}