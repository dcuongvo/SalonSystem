using SalonSystem.Domain.Entities.Appointments;
using SalonSystem.Infrastructure.Repositories.Base.Interfaces;

namespace SalonSystem.Infrastructure.Repositories.Appointments.Interfaces
{
    public interface IAppointmentTechnicianRepository : IRepository<AppointmentTechnician>
    {
        Task<IEnumerable<AppointmentTechnician>> GetByTechnicianIdAsync(int technicianId);
    }
}
