using  SalonSystem.Models.Services;
using  SalonSystem.Models.Skills;

namespace SalonSystem.Models.Skills
{
    public class ServiceSkill
    {
        public int ServiceId { get; set; }
        public Service? Service { get; set; }  

        public int SkillId { get; set; }
        public Skill? Skill { get; set; }  

        public ServiceSkill() { }


        public ServiceSkill(int serviceId, int skillId)
        {
            ServiceId = serviceId;
            SkillId = skillId;
        }
    }
}