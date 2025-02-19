using SalonSystem.Domain.Entities.Technicians;
using SalonSystem.Infrastructure.Repositories.Base.Interfaces;

namespace SalonSystem.Infrastructure.Repositories.Technicians.Interfaces
{
    public interface ITechnicianRepository : IRepository<Technician>
    {
        Task<IEnumerable<Technician>> GetTechniciansBySalonIdAsync(int salonId);
        Task<bool> IsTechnicianAvailableAsync(int technicianId, DateTime dateTime, TimeSpan duration);
    }
}
