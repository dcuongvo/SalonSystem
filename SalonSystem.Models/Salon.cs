namespace SalonSystem.Models.Salons;
using SalonSystem.Models.Services;
using SalonSystem.Models.Technicians;
using SalonSystem.Models.WorkingHours;

public class Salon {
    public ICollection<Technician> Technicians {get;set;}
    public ICollection<Service> Services {get;set;}
    public int SalonId{get; private set;}
    public string Name {get;set;}
    //public Dictionary<DayOfWeek, WorkingHours> WeeklyWorkingHours { get; set; }

    //Constructor with only name
    public Salon(string name) {
        Name = name;
        //WeeklyWorkingHours = new Dictionary<DayOfWeek, WorkingHours>();
        Technicians = new List<Technician>();
        Services = new List<Service>();
    }

    public void AddService(Service newService) {
        Services.Add(newService);
    }

    public void AddTechnician(Technician technician)
    {
        Technicians.Add(technician);
    }

    public Service? findServiceByName(string name) {
        foreach (Service service in Services) {
            if (service.ServiceName == name) return service;
        }
        return null; 
    }

    public List<Technician> FindTechniciansByName(string name)
    {
        List<Technician> matchedTechnician = [];
        foreach (Technician technician in Technicians) {
            if (technician.Name == name) matchedTechnician.Add(technician);
        }
        return matchedTechnician;
    }

    public List<Technician> FindTechnicianToPerform(Service service) 
    {
        List<Technician> qualifiedTechnicians = new List<Technician>();
        foreach (Technician technician in Technicians) {
            if (service.CanBePerformedBy(technician)) {
                qualifiedTechnicians.Add(technician);
            }
        }
        return qualifiedTechnicians;
    }


    public void AddService(string name, int duration = -1) => Services.Add(new Service(name));

    //For future development
    //Set Working Hour for the salon.
    /*
    public void SetWorkingHours(DayOfWeek day, TimeSpan openingTime, TimeSpan closingTime)
    {
        WeeklyWorkingHours[day] = new WorkingHours(openingTime, closingTime);
    }

    //check if the name salon is open at the specific time.
    public bool isOpen(DayOfWeek day, TimeSpan time) 
    {
        if (WeeklyWorkingHours.ContainsKey(day)) {
            var hours = WeeklyWorkingHours[day];
            return time >=hours.OpeningTime && time <= hours.ClosingTime;
        }
        return false;
    }
    // check if the salon is open on a day of the week.
    public bool boolisOpenOnDay(DayOfWeek day) 
    {
        if (WeeklyWorkingHours.ContainsKey(day)) return true;
        return false;
    }
    */ 

}

