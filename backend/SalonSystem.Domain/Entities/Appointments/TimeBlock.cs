using SalonSystem.Domain.Entities.Technicians;

namespace SalonSystem.Domain.Entities.Appointments
{
    public class TimeBlock
    {
        public int TimeBlockId { get; set; }
        public int TechnicianScheduleId { get; set; }
        public virtual TechnicianSchedule? TechnicianSchedule { get; set; }
        public DateTime BlockTime { get; set; }
        public bool IsAvailable { get; set; } = true;
        public int? AppointmentId { get; set; }
        public virtual Appointment? Appointment { get; set; }
    }
}
