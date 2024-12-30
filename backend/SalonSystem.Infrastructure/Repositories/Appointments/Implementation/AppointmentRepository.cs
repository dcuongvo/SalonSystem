using Microsoft.EntityFrameworkCore;
using SalonSystem.Domain.Entities.Appointments;
using SalonSystem.Infrastructure.Repositories.Appointments.Interfaces;
using SalonSystem.Infrastructure.Repositories.Base.Implementations;

namespace SalonSystem.Infrastructure.Repositories.Appointments.Implementations
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        private readonly DbContext _context;

        public AppointmentRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetByTechnicianAndDateAsync(int technicianId, DateTime date)
        {
            return await _context.Set<Appointment>()
                .Where(a => a.TechnicianId == technicianId && a.AppointmentTime.Date == date.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByDateAsync(DateTime date)
        {
            return await _context.Set<Appointment>()
                .Where(a => a.AppointmentTime.Date == date.Date)
                .ToListAsync();
        }
    }
}
