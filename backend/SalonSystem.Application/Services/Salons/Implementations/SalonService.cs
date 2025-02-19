using SalonSystem.Domain.Entities.Salons;
using SalonSystem.Infrastructure.Repositories.Salons.Interfaces;
using SalonSystem.Application.Services.Salons.Interfaces;


namespace SalonSystem.Application.Services.Salons.Implementations
{
    public class SalonService : ISalonService
    {
        private readonly ISalonRepository _salonRepository;

        public SalonService(ISalonRepository salonRepository)
        {
            _salonRepository = salonRepository;
        }

        public async Task<bool> AddSalonAsync(Salon salon)
        {
            if (string.IsNullOrWhiteSpace(salon.Name) || string.IsNullOrWhiteSpace(salon.Address))
            {
                throw new ArgumentException("Salon name and address are required.");
            }

            return await _salonRepository.AddAsync(salon);
        }
    }
}
