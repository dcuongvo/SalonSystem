

using SalonSystem.Models.Skills;
using SalonSystem.Models.Technicians;
using SalonSystem.Models.Salons;

namespace SalonSystem.Models.Services 
{
    public class Service {
        public int ServiceId { get; set; } 
        public string ServiceName {get;set;}
        public int SalonId { get; set; } 
        public Salon AssociatedSalon { get; set; } 
        public ICollection<Skill> RequiredSkills { get; set; }

        public ICollection<ServiceSkill> ServiceSkills { get; set; }

        public Service() {
            ServiceName = "No Name";
            RequiredSkills = new List<Skill>();
        }
        public Service(string name, List<Skill> requiredSkills) 
        {
            ServiceName = name;
            RequiredSkills = requiredSkills;
        }

        public  void addRequiredSkill(Skill skill) => RequiredSkills.Add(skill);

        public Service(string name) 
        {
            ServiceName = name;
            RequiredSkills = new List<Skill>();
        }

        public bool CanBePerformedBy(Technician technician)
        {
            //return RequiredSkills.All(skill => technician.SkillSet.Contains(skill));
            foreach (Skill requiredSkill in RequiredSkills) 
            {
                bool hasSkill = false;
                foreach (Skill techSkill in technician.SkillSet) 
                {
                    //Console.WriteLine($"Checking skill {techSkill.Name} against required skill {requiredSkill.Name}");
                    if ( requiredSkill.SkillName == techSkill.SkillName) {
                        hasSkill = true;
                        break;
                    }
                    //Console.WriteLine(hasSkill);
                }
                if (!hasSkill) return false;
            }
            return true;
        }

    }
}