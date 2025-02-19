using SalonSystem.Domain.Entities.Appointments;
using SalonSystem.Infrastructure.Repositories.Base.Interfaces;

namespace SalonSystem.Infrastructure.Repositories.Appointments.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAppointmentsByDateAsync(DateTime date);
        Task<IEnumerable<Appointment>> GetAppointmentsBySalonIdAsync(int salonId);
    }
}
