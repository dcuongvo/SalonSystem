using SalonSystem.Data.Repositories;
using SalonSystem.Models.Technician;
using System.Collection.Generic;
using System.Threading.Tasks;

namespace SalonSystem.Services 
{
    public class TechnicianService
    {
        private readonly ITechnicianRepository _technicianRepository;

        public TechnicianService(ITechnicianRepository technicianRepository)
        {
            _technicianRepository = technicianRepository;
        }

        // Get all technicians
        public async Task<IEnumerable<Technician>> GetAllTechniciansAsync()
        {
            return await _technicianRepository.GetAllTechniciansAsync();
        }

        // Get technician by ID
        public async Task<Technician> GetTechnicianByIdAsync(int id)
        {
            return await _technicianRepository.GetTechnicianByIdAsync(id);
        }

        // Add new technician
        public async Task<Technician> AddTechnicianAsync(Technician technician)
        {
            // Business logic can be added here before adding (e.g., validation)
            return await _technicianRepository.AddTechnicianAsync(technician);
        }

        // Update technician 
        public async Task<Technician> UpdateTechnicianAsync(int id, Technician technician)
        {
            if (id != technician.TechnicianId)
            {
                return null; // Or throw an exception based on your needs
            }

            return await _technicianRepository.UpdateTechnicianAsync(technician);
        }

        // Delete a technician
        public async Task<bool> DeleteTechnicianAsync(int id)
        {
            return await _technicianRepository.DeleteTechnicianAsync(id);
        }
    }

}