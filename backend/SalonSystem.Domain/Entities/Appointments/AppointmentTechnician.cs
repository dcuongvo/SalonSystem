using SalonSystem.Domain.Entities.Technicians;

namespace SalonSystem.Domain.Entities.Appointments
{
    public class AppointmentTechnician
    {
        public int AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; } = null!;

        public int TechnicianId { get; set; }
        public virtual Technician Technician { get; set; } = null!;
    }
}
