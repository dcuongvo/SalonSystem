using SalonSystem.Domain.Entities.Salons;
using SalonSystem.Domain.Entities.Technicians;

namespace SalonSystem.Domain.Entities.Services
{
    public class Skill
    {
        public int SkillId { get; set; } // Primary Key
        public string SkillName { get; set; } = string.Empty; // Name of the skill

        public int SalonId { get; set; } // Foreign Key to Salon
        public virtual Salon AssociatedSalon { get; set; } // Navigation Property

        public int Duration { get; set; } = -1; // Duration in minutes (optional)

        public ICollection<TechnicianSkill> TechnicianSkills { get; set; } = new List<TechnicianSkill>();
        public ICollection<ServiceSkill> ServiceSkills { get; set; } = new List<ServiceSkill>();

        // Constructors
        public Skill() {}

        public Skill(string name, int duration = -1, int salonId = 0)
        {
            SkillName = name;
            Duration = duration;
            SalonId = salonId;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Skill otherSkill)
            {
                return SkillId == otherSkill.SkillId || 
                    (SkillName == otherSkill.SkillName && SalonId == otherSkill.SalonId);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SkillId, SkillName, SalonId);
        }

    }
}
