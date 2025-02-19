using SalonSystem.Application.Services.Appointments.Interfaces;
using SalonSystem.Domain.Entities.Appointments;
using SalonSystem.Infrastructure.Repositories.Appointments.Interfaces;
using SalonSystem.Application.Services.Base.Implementations;

namespace SalonSystem.Application.Services.Appointments.Implementations
{
    public class AppointmentService : GenericService<Appointment>, IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ITimeBlockRepository _timeBlockRepository;

        public AppointmentService(
            IAppointmentRepository appointmentRepository,
            ITimeBlockRepository timeBlockRepository
        ) : base(appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
            _timeBlockRepository = timeBlockRepository;
        }

        public async Task<Appointment?> CreateAppointmentAsync(Appointment appointment, ICollection<int> timeBlockIds)
        {
            // Validate time blocks and mark as occupied
            foreach (var timeBlockId in timeBlockIds)
            {
                await _timeBlockRepository.MarkAsOccupiedAsync(timeBlockId, appointment.AppointmentId);
            }

            // Save the appointment
            await _appointmentRepository.AddAsync(appointment);
            return appointment;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDateAsync(DateTime date)
        {
            return await _appointmentRepository.GetAppointmentsByDateAsync(date);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsBySalonIdAsync(int salonId)
        {
            return await _appointmentRepository.GetAppointmentsBySalonIdAsync(salonId);
        }

        public async Task<bool> CheckTechnicianAvailabilityAsync(int technicianId, DateTime appointmentTime, TimeSpan duration)
        {
            // Validate against time blocks or direct repository checks for conflicts
            var availableBlocks = await _timeBlockRepository.GetAvailableBlocksAsync(technicianId, appointmentTime, appointmentTime + duration);
            return availableBlocks.Any();
        }
    }
}
