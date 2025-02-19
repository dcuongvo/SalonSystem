using SalonSystem.Domain.Entities.Appointments;
using SalonSystem.Application.Services.Base.Interfaces;

namespace SalonSystem.Application.Services.Appointments.Interfaces
{
    public interface IAppointmentService : IGenericService<Appointment>
    {
        Task<Appointment?> CreateAppointmentAsync(Appointment appointment, ICollection<int> timeBlockIds);
        Task<IEnumerable<Appointment>> GetAppointmentsByDateAsync(DateTime date);
        Task<IEnumerable<Appointment>> GetAppointmentsBySalonIdAsync(int salonId);
        Task<bool> CheckTechnicianAvailabilityAsync(int technicianId, DateTime appointmentTime, TimeSpan duration);
    }
}
