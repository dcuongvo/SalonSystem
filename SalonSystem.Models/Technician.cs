

using SalonSystem.Models.Skills;
using SalonSystem.Models.Employees;
using SalonSystem.Models.Services;
using SalonSystem.Models.Salons;
using System.Dynamic;

namespace SalonSystem.Models.Technicians 
{
    public class Technician : Employee
    {
        public int TechnicianId { get; set; }
        public int SalonId { get; set; }
        public Salon AssociatedSalon {get;set;}
        public ICollection<Skill> SkillSet {get; set;}
         public ICollection<TechnicianSkill> TechnicianSkills { get; set; }

        public Technician (int id, string name, int salary, PayPeriod payPeriodType = PayPeriod.Weekly)
            :base(id,name,salary,payPeriodType) 
        {
            SkillSet = new List<Skill>();
        }

        public bool CanPerformService(Service service)
        {
            return service.CanBePerformedBy(this);
        }
        
        public void AddSkill(string skill, int duration = -1) => SkillSet.Add(new Skill(skill,duration));
        public void AddSkill(Skill skill) => SkillSet.Add(skill);
        public void AddSkill(List<Skill> skillList) 
        {
            foreach (Skill skill in skillList ) SkillSet.Add(skill);
        }
    }
}
