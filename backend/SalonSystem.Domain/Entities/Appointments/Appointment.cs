using SalonSystem.Domain.Entities.Technicians;

namespace SalonSystem.Domain.Entities.Appointments
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentTime { get; set; } 
        public TimeSpan Duration { get; set; } 
        public ICollection<AppointmentService> AppointmentServices { get; set; } = new List<AppointmentService>();
        public ICollection<AppointmentTechnician> AppointmentTechnicians { get; set; } = new List<AppointmentTechnician>();
    }
}
