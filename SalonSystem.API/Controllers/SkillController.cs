using Microsoft.AspNetCore.Mvc;
using SalonSystem.Models.Skills;
using SalonSystem.Services;

namespace SkillSystem.API.Controllers  
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase 
    {
        private readonly SkillService _skillService;

        public SkillController(SkillService skillService)
        {
            _skillService = skillService;
        }

        //GET http request to get all techncians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skill>>> GetAllSkill()
        {
            var skills = await _skillService.GetAllSkillsAsync();
            return Ok(skills);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> GetSkillById(int id) 
        {
            var skill = await _skillService.GetSkillByIdAsync(id);
            if (skill == null)
            {
                return NotFound();
            } 
            return Ok(skill);
        }

        [HttpPost]
        public async Task<ActionResult<Skill>> AddSkill(Skill skill)
        {
            var newSkill = await _skillService.AddSkillAsync(skill);                                       
            return CreatedAtAction(nameof(GetSkillById), new {id = newSkill.SkillId}, newSkill);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSkill(int id, Skill skill) 
        {
            if (id != skill.SkillId) 
            {
                return BadRequest();
            }

            var updatedSkill = await _skillService.UpdateSkillAsync(id,skill);
            if (updatedSkill == null) 
            {
                return NotFound();
            }
            return NoContent();
            //return Ok(updatedSkill)
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var result = await _skillService.DeleteSkillAsync(id);
            if (!result) 
            {
                return NotFound();
            }
            return NoContent();
            //return Ok()?
        }

    } 
}