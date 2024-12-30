using SalonSystem.Domain.Entities.Salons;
using SalonSystem.Infrastructure.Repositories.Base.Interfaces;


namespace SalonSystem.Infrastructure.Repositories.Salons.Interfaces
{
    public interface IDayCloseRepository : IRepository<DayClose>
    {
        Task<bool> IsSalonClosedOnDateAsync(int salonId, DateTime date);

        Task<IEnumerable<DayClose>> GetBySalonIdAsync(int salonId);
    }
}
