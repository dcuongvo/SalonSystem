using SalonSystem.Models.Technicians;
using SalonSystem.Models.Skills;
using System.Diagnostics.Contracts;

namespace SalonSystem.Models.Skills
{
    public class TechnicianSkill
    {
        public int TechnicianId {get; set;}
        public Technician? Technician;
        public int SkillId;
        public Skill? Skill;

    public TechnicianSkill(){}

    public TechnicianSkill(int technicianId, int skillId)
        {
            TechnicianId = technicianId;
            SkillId = skillId;
        }
    }
}