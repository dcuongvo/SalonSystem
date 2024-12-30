using SalonSystem.Common.Enums;
using SalonSystem.Domain.Entities.Employees;
using SalonSystem.Domain.Entities.Services;
using SalonSystem.Domain.Entities.Appointments;
using SalonSystem.Domain.Entities.Salons;

namespace SalonSystem.Domain.Entities.Technicians
{
    public class Technician : Employee
    {
        public ICollection<TechnicianSkill> TechnicianSkills { get; set; } = new List<TechnicianSkill>();
        public ICollection<TechnicianSchedule> TechnicianSchedules { get; set; } = new List<TechnicianSchedule>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<DayOff> DaysOff { get; set; } = new List<DayOff>();

        // Constructors
        public Technician() { }

        public Technician(int id, string name, int salary, PayPeriod payPeriodType, int salonId)
            : base(id, name, salary, payPeriodType, salonId) { }

        // Methods
        public bool IsAvailable(DateTime appointmentTime, TimeSpan duration, ICollection<DayClose> dayCloses)
        {
            if (duration <= TimeSpan.Zero)
                throw new ArgumentException("Duration must be greater than zero.", nameof(duration));

            if (dayCloses == null)
                throw new ArgumentNullException(nameof(dayCloses));

            var dayOfWeek = appointmentTime.DayOfWeek;
            var date = appointmentTime.Date;
            var timeOfDay = appointmentTime.TimeOfDay;

            // 1. Check if the salon is closed on this date
            if (dayCloses.Any(dc => dc.Date.Date == date))
                return false;

            // 2. Check if the technician has a day off on this date
            if (DaysOff.Any(d => d.Date.Date == date))
                return false;

            // 3. Check if the technician has a valid schedule for this day and time
            bool withinSchedule = TechnicianSchedules.Any(schedule =>
                schedule.IsAvailable &&
                schedule.Day == dayOfWeek &&
                timeOfDay >= schedule.StartTime &&
                timeOfDay + duration <= schedule.EndTime);

            if (!withinSchedule)
                return false;

            // 4. Check if there are any conflicting appointments
            bool noConflicts = !Appointments.Any(appointment =>
                appointmentTime < appointment.AppointmentTime + appointment.Duration &&
                appointmentTime + duration > appointment.AppointmentTime);

            return noConflicts;
        }

        public bool CanPerformService(Service service)
        {
            return service.ServiceSkills.All(serviceSkill =>
                TechnicianSkills.Any(techSkill => techSkill.Skill.Equals(serviceSkill.Skill)));
        }
    }
}
