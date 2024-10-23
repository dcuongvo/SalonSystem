using SalonSystem.Data.Repositories;
using SalonSystem.Models.Salons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalonSystem.Services 
{
    public class SalonService
    {
        private readonly ISalonRepository _salonRepository;

        public SalonService(ISalonRepository salonRepository)
        {
            _salonRepository = salonRepository;
        }

        // Get all salons
        public async Task<IEnumerable<Salon>> GetAllSalonsAsync()
        {
            return await _salonRepository.GetAllSalonsAsync();
        }

        // Get salon by ID
        public async Task<Salon> GetSalonByIdAsync(int id)
        {
            return await _salonRepository.GetSalonByIdAsync(id);
        }

        // Add new salon
        public async Task<Salon> AddSalonAsync(Salon salon)
        {
            // need to update more logic after adding salon service
            return await _salonRepository.AddSalonAsync(salon);
        }

        // Update salon 
        public async Task<Salon> UpdateSalonAsync(int id, Salon salon)
        {
            if (id != salon.SalonId)
            {
                return null; //revisit
            }

            return await _salonRepository.UpdateSalonAsync(salon);
        }

        // Delete a salon
        public async Task<bool> DeleteSalonAsync(int id)
        {
            return await _salonRepository.DeleteSalonAsync(id);
        }
    }

}