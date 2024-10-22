using SalonSystem.Models.Salons;


namespace SalonSystem.Models.Skills {
    public class Skill 
    {
        public int SkillId {get;set;}
        public string SkillName {set ; get;}

        public int SalonId {get;set;}
        public Salon AssociatedSalon {get;set;}
        public int Duration {set;get;}

        public ICollection<TechnicianSkill> TechnicianSkills { get; set; }
        public ICollection<ServiceSkill> ServiceSkills { get; set; }

        public Skill(string name, int duration = -1) => (SkillName, Duration) = (name, duration);
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is Skill otherSkill)
            {
                return SkillName == otherSkill.SkillName;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return SkillName != null ? SkillName.GetHashCode() : 0;
        }
    }
}