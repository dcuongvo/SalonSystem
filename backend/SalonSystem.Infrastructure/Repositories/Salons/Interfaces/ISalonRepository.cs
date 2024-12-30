using SalonSystem.Domain.Entities.Salons;
using SalonSystem.Infrastructure.Repositories.Base.Interfaces;

namespace SalonSystem.Infrastructure.Repositories.Salons.Interfaces
{
    public interface ISalonRepository : IRepository<Salon>
    {
        Task<IEnumerable<Salon>> GetByOwnerIdAsync(int ownerId);
        Task<Salon?> GetSalonDetailsAsync(int salonId);
    }
}
