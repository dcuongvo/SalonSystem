using Microsoft.EntityFrameworkCore;
using SalonSystem.Domain.Entities.Appointments;
using SalonSystem.Infrastructure.Data;
using SalonSystem.Infrastructure.Repositories.Appointments.Interfaces;
using SalonSystem.Infrastructure.Repositories.Base.Implementations;

namespace SalonSystem.Infrastructure.Repositories.Appointments.Implementations
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        private readonly SalonSystemDbContext _context;

        public AppointmentRepository(SalonSystemDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDateAsync(DateTime date)
        {
            return await _context.Appointments
                .Where(a => a.AppointmentTime.Date == date.Date)
                .Include(a => a.AppointmentServices)
                    .ThenInclude(aservice => aservice.Service)
                .Include(a => a.AppointmentTechnicians)
                    .ThenInclude(atech => atech.Technician)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsBySalonIdAsync(int salonId)
        {
            return await _context.Appointments
                .Where(a => a.AppointmentTechnicians
                    .Any(atech => atech.Technician.SalonId == salonId))
                .Include(a => a.AppointmentServices)
                    .ThenInclude(aservice => aservice.Service)
                .Include(a => a.AppointmentTechnicians)
                    .ThenInclude(atech => atech.Technician)
                .ToListAsync();
        }
    }
}
