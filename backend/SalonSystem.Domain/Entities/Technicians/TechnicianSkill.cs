using SalonSystem.Domain.Entities.Services;
namespace SalonSystem.Domain.Entities.Technicians
{
    public class TechnicianSkill
    {
        public int TechnicianId { get; set; } // Foreign Key to Technician
        public virtual required Technician Technician { get; set; } // Navigation Property

        public int SkillId { get; set; } // Foreign Key to Skill
        public virtual required Skill Skill { get; set; } // Navigation Property

        // Constructors
        public TechnicianSkill() { }

        public TechnicianSkill(int technicianId, int skillId)
        {
            TechnicianId = technicianId;
            SkillId = skillId;
        }

        public TechnicianSkill(Technician technician, Skill skill)
        {
            Technician = technician;
            Skill = skill;
        }
    }
}
