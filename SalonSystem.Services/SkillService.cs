using SalonSystem.Data.Repositories;
using SalonSystem.Models.Skills;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalonSystem.Services 
{
    public class SkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        // Get all skills
        public async Task<IEnumerable<Skill>> GetAllSkillsAsync()
        {
            return await _skillRepository.GetAllSkillsAsync();
        }

        // Get skill by ID
        public async Task<Skill> GetSkillByIdAsync(int id)
        {
            return await _skillRepository.GetSkillByIdAsync(id);
        }

        // Add new skill
        public async Task<Skill> AddSkillAsync(Skill skill)
        {
            // need to update more logic after adding salon service
            return await _skillRepository.AddSkillAsync(skill);
        }

        // Update skill 
        public async Task<Skill> UpdateSkillAsync(int id, Skill skill)
        {
            if (id != skill.SkillId)
            {
                return null; //revisit
            }

            return await _skillRepository.UpdateSkillAsync(skill);
        }

        // Delete a skill
        public async Task<bool> DeleteSkillAsync(int id)
        {
            return await _skillRepository.DeleteSkillAsync(id);
        }
    }

}