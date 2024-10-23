using SalonSystem.Data.Repositories;
using SalonSystem.Models.Technicians;
using System.Collections.Generic;
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
            // need to update more logic after adding salon service
            return await _technicianRepository.AddTechnicianAsync(technician);
        }

        // Update technician 
        public async Task<Technician> UpdateTechnicianAsync(int id, Technician technician)
        {
            if (id != technician.TechnicianId)
            {
                return null; //revisit
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