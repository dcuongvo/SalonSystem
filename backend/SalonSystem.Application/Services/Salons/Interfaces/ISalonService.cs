using SalonSystem.Domain.Entities.Salons;

namespace SalonSystem.Application.Services.Salons.Interfaces
{
    public interface ISalonService
    {
        Task<bool> AddSalonAsync(Salon salon);
    }
}
