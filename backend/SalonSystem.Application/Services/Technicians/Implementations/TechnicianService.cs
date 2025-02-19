using SalonSystem.Application.Services.Technicians.Interfaces;
using SalonSystem.Domain.Entities.Technicians;
using SalonSystem.Infrastructure.Repositories.Technicians.Interfaces;
using SalonSystem.Application.Services.Base.Implementations;

namespace SalonSystem.Application.Services.Technicians.Implementations
{
    public class TechnicianService : GenericService<Technician>, ITechnicianService
    {
        private readonly ITechnicianRepository _technicianRepository;
        private readonly ITechnicianScheduleRepository _scheduleRepository;
        private readonly ITechnicianSkillRepository _skillRepository;

        public TechnicianService(
            ITechnicianRepository technicianRepository,
            ITechnicianScheduleRepository scheduleRepository,
            ITechnicianSkillRepository skillRepository
        ) : base(technicianRepository)
        {
            _technicianRepository = technicianRepository;
            _scheduleRepository = scheduleRepository;
            _skillRepository = skillRepository;
        }

        public async Task<IEnumerable<Technician>> GetTechniciansBySalonIdAsync(int salonId)
        {
            return await _technicianRepository.GetTechniciansBySalonIdAsync(salonId);
        }

        public async Task<bool> IsTechnicianAvailableAsync(int technicianId, DateTime dateTime, TimeSpan duration)
        {
            return await _technicianRepository.IsTechnicianAvailableAsync(technicianId, dateTime, duration);
        }

        public async Task<TechnicianSchedule?> GetScheduleByTechnicianAndDayAsync(int technicianId, DayOfWeek day)
        {
            return await _scheduleRepository.GetScheduleByTechnicianAndDayAsync(technicianId, day);
        }

        public async Task<IEnumerable<TechnicianSkill>> GetSkillsByTechnicianIdAsync(int technicianId)
        {
            return await _skillRepository.GetSkillsByTechnicianIdAsync(technicianId);
        }
    }
}
