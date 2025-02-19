using Microsoft.EntityFrameworkCore;
using SalonSystem.Domain.Entities.Technicians;
using SalonSystem.Infrastructure.Data;
using SalonSystem.Infrastructure.Repositories.Technicians.Interfaces;
using SalonSystem.Infrastructure.Repositories.Base.Implementations;

namespace SalonSystem.Infrastructure.Repositories.Technicians.Implementations
{
    public class TechnicianRepository : GenericRepository<Technician>, ITechnicianRepository
    {
        private readonly SalonSystemDbContext _context;

        public TechnicianRepository(SalonSystemDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Technician>> GetTechniciansBySalonIdAsync(int salonId)
        {
            return await _context.Technicians
                .Where(t => t.SalonId == salonId)
                .Include(t => t.TechnicianSkills)
                    .ThenInclude(ts => ts.Skill)
                .Include(t => t.TechnicianSchedules)
                .Include(t => t.DaysOff)
                .Include(t => t.AppointmentTechnicians)
                    .ThenInclude(at => at.Appointment)
                .ToListAsync();
        }

        public async Task<bool> IsTechnicianAvailableAsync(int technicianId, DateTime dateTime, TimeSpan duration)
        {
            // Check if the technician has a day off
            bool isDayOff = await _context.DaysOff
                .AnyAsync(doff => doff.TechnicianId == technicianId && doff.Date.Date == dateTime.Date);

            if (isDayOff)
                return false;

            // Check if the technician has a valid schedule for this time
            var schedules = await _context.TechnicianSchedules
                .Where(s => s.TechnicianId == technicianId && s.Day == dateTime.DayOfWeek)
                .ToListAsync();

            bool withinSchedule = schedules.Any(s =>
                s.IsAvailable &&
                dateTime.TimeOfDay >= s.StartTime &&
                dateTime.TimeOfDay + duration <= s.EndTime);

            if (!withinSchedule)
                return false;

            // Check for conflicting appointments
            bool hasConflicts = await _context.AppointmentTechnicians
                .Include(at => at.Appointment)
                .Where(at => at.TechnicianId == technicianId)
                .AnyAsync(at =>
                    dateTime < at.Appointment.AppointmentTime + at.Appointment.Duration &&
                    dateTime + duration > at.Appointment.AppointmentTime);

            return !hasConflicts;
        }
    }
}
