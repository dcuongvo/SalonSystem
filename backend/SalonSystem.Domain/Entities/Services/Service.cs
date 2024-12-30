using SalonSystem.Domain.Entities.Salons;
using SalonSystem.Domain.Entities.Technicians;

namespace SalonSystem.Domain.Entities.Services
{
    public class Service
    {
        public int ServiceId { get; set; } 
        public string ServiceName { get; set; } = string.Empty; 

        public int SalonId { get; set; } 
        public virtual Salon? AssociatedSalon { get; set; }
        public int Duration {get;set;} = -1;

        public ICollection<ServiceSkill> ServiceSkills { get; set; } = new List<ServiceSkill>(); // Required skills for this service

        // Constructors
        public Service() {}

        public Service(string serviceName, int salonId)
        {
            ServiceName = serviceName;
            SalonId = salonId;
        }
        public Service(string serviceName, int salonId,Salon associatedSalon, int duration)
        {
            ServiceName = serviceName;
            SalonId = salonId;
            AssociatedSalon = associatedSalon;
            Duration = duration;
        }

        // Method to add a required skill
        public void AddRequiredSkill(Skill skill)
        {
            if (ServiceSkills.Any(ss => ss.Equals(skill)))
            {
                throw new InvalidOperationException($"Skill '{skill.SkillName}' is already required for this service.");
            }

            ServiceSkills.Add(new ServiceSkill
            {
                ServiceId = this.ServiceId,
                Service = this,
                SkillId = skill.SkillId,
                Skill = skill
            });
        }

        // Method to check if a technician can perform the service
        public bool CanBePerformedBy(Technician technician)
        {
            return ServiceSkills.All(serviceSkill =>
                technician.TechnicianSkills.Any(techSkill =>
                    techSkill.Skill.Equals(serviceSkill.Skill)));
        }
    }
}
