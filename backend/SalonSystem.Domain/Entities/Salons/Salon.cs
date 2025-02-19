using SalonSystem.Domain.Entities.Services;
using SalonSystem.Domain.Entities.Technicians;
using SalonSystem.Domain.Entities.Users;

namespace SalonSystem.Domain.Entities.Salons
{
    public class Salon
    {

        
        public int SalonId { get; private set; } // Primary Key
        public string Name { get; set; } = ""; // Salon Name
        public int OwnerId { get; set; }
        public User? Owner { get; set; }
        public string Address { get; set; } 
        public string City { get; set; } 
        public string State { get; set; } 
        public string ZipCode { get; set; } 
        public string Country {get;set;} = "USA";
        public ICollection<Technician> Technicians { get; set; } = new List<Technician>(); // Working Technicians
        public ICollection<Service> Services { get; set; } = new List<Service>(); // All Offering Services
        public ICollection<Skill> Skills { get; set; } = new List<Skill>(); // 
        public ICollection<SalonSchedule> SalonSchedules { get; set; } = new List<SalonSchedule>(); // Operating Hours
        public ICollection<DayClose> DayCloses { get; set; } = new List<DayClose>(); // Closed Days

        // Constructors
        public Salon() {}

        public Salon(string name)
        {
            Name = name;
        }

        // Methods

        // Add a service to the salon
        public void AddService(Service newService)
        {
            Services.Add(newService);
        }

        // Add a technician to the salon
        public void AddTechnician(Technician technician)
        {
            Technicians.Add(technician);
        }

        // Find a service by name
        public Service? FindServiceByName(string name)
        {
            return Services.FirstOrDefault(service => service.ServiceName == name);
        }

        // Find technicians by name
        public List<Technician> FindTechniciansByName(string name)
        {
            return Technicians.Where(technician => technician.Name == name).ToList();
        }

        // Find technicians qualified to perform a specific service
        public List<Technician> FindTechniciansToPerform(Service service)
        {
            return Technicians.Where(technician => service.CanBePerformedBy(technician)).ToList();
        }

        // Add a new service by name
        public void AddService(string name, int duration = -1)
        {
            Services.Add(new Service(name,SalonId,this,duration));
        }

        // Check if the salon is open on a specific date and time
        public bool IsOpen(DateTime dateTime)
        {
            // Check for DayClose
            bool isDayClose = DayCloses.Any(dc => dc.Date.Date == dateTime.Date);
            if (isDayClose) return false;

            // Check operating hours for the day
            var salonSchedule = SalonSchedules.FirstOrDefault(schedule => schedule.Day == dateTime.DayOfWeek);
            if (salonSchedule == null) return false;

            var timeOfDay = dateTime.TimeOfDay;
            return timeOfDay >= salonSchedule.OpenTime && timeOfDay <= salonSchedule.CloseTime;
        }
    }
}
