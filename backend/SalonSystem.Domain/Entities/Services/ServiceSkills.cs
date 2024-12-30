

namespace SalonSystem.Domain.Entities.Services
{
    public class ServiceSkill
    {
        public int ServiceId { get; set; } // Foreign Key to Service
        public virtual Service Service { get; set; } // Navigation Property

        public int SkillId { get; set; } // Foreign Key to Skill
        public virtual Skill Skill { get; set; } // Navigation Property

        // Constructor
        public ServiceSkill() { }

        public ServiceSkill(int serviceId, int skillId)
        {
            ServiceId = serviceId;
            SkillId = skillId;
        }

        public ServiceSkill(Service service, Skill skill)
        {
            Service = service;
            Skill = skill;
        }
    }
}
