using SalonSystem.Domain.Entities.Salons;
using SalonSystem.Infrastructure.Repositories.Base.Interfaces;

namespace SalonSystem.Infrastructure.Repositories.Salons.Interfaces
{
    public interface IDayCloseRepository : IRepository<DayClose>
    {
        Task<IEnumerable<DayClose>> GetDayClosesBySalonIdAsync(int salonId);
    }
}
