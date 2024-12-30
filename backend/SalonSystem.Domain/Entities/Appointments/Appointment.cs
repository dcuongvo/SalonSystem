using SalonSystem.Domain.Entities.Common;
using SalonSystem.Domain.Entities.Technicians;

namespace SalonSystem.Domain.Entities.Appointments
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int TechnicianId { get; set; } 
        public virtual Technician? Technician { get; set; } 
        public int ServiceId { get; set; } 
        public virtual Service Service { get; set; } 

        public DateTime AppointmentTime { get; set; } 
        public TimeSpan Duration { get; set; } 
    }
}
