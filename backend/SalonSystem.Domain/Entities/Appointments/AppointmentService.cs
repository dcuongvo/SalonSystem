using SalonSystem.Domain.Entities.Services;

namespace SalonSystem.Domain.Entities.Appointments
{
    public class AppointmentService
    {
        public int AppointmentId { get; set; } // Foreign Key to Appointment
        public virtual Appointment Appointment { get; set; } = null!;

        public int ServiceId { get; set; } // Foreign Key to Service
        public virtual Service Service { get; set; } = null!;
    }
}
