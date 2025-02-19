using Microsoft.EntityFrameworkCore;
using SalonSystem.Domain.Entities.Appointments;
using SalonSystem.Infrastructure.Data;
using SalonSystem.Infrastructure.Repositories.Appointments.Interfaces;
using SalonSystem.Infrastructure.Repositories.Base.Implementations;

namespace SalonSystem.Infrastructure.Repositories.Appointments.Implementations
{
    public class AppointmentTechnicianRepository : GenericRepository<AppointmentTechnician>, IAppointmentTechnicianRepository
    {
        private readonly SalonSystemDbContext _context;

        public AppointmentTechnicianRepository(SalonSystemDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppointmentTechnician>> GetByTechnicianIdAsync(int technicianId)
        {
            return await _context.AppointmentTechnicians
                .Where(at => at.TechnicianId == technicianId)
                .Include(at => at.Appointment)
                .ToListAsync();
        }
    }
}
