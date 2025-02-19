using SalonSystem.Domain.Entities.Salons;
using SalonSystem.Infrastructure.Repositories.Base.Interfaces;

namespace SalonSystem.Infrastructure.Repositories.Salons.Interfaces
{
    public interface ISalonRepository : IRepository<Salon>
    {
        Task<Salon?> GetSalonWithDetailsAsync(int salonId);
        Task<IEnumerable<Salon>> GetAllSalonsByOwnerIdAsync(int ownerId);
    }
}
