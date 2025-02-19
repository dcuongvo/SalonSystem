using SalonSystem.Domain.Entities.Salons;
using SalonSystem.Infrastructure.Repositories.Base.Interfaces;

namespace SalonSystem.Infrastructure.Repositories.Salons.Interfaces
{
    public interface ISalonScheduleRepository : IRepository<SalonSchedule>
    {
        Task<IEnumerable<SalonSchedule>> GetSchedulesBySalonIdAsync(int salonId);
        Task<bool> IsSalonOpenAsync(int salonId, DateTime dateTime);
    }
}
