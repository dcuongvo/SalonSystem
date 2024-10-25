using Microsoft.EntityFrameworkCore;
using SalonSystem.Data.Repositories;
using SalonSystem.Models.Technicians;
using System.Collections.Generic;
using System.Threading.Tasks;
using SalonSystem.DTOs;
using SalonSystem.Data;
using SalonSystem.Models.Skills;

namespace SalonSystem.Services 
{
    public class TechnicianService
    {
        private readonly ITechnicianRepository _technicianRepository;
        private readonly SalonSystemDbContext _dbContext;


        public TechnicianService(ITechnicianRepository technicianRepository, SalonSystemDbContext dbContext)
        {
            _technicianRepository = technicianRepository ?? throw new ArgumentNullException(nameof(technicianRepository));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
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
        public async Task<Technician> AddTechnicianAsync(CreateTechnicianDto technicianDto)
        {
            if (technicianDto == null)
            {
                throw new ArgumentNullException(nameof(technicianDto), "Technician data is required.");
            }
            if (string.IsNullOrEmpty(technicianDto.Name))
            {
                throw new ArgumentException("Technician name cannot be null or empty");
            }

            // Fetch associated salon from the database
            var associatedSalon = await _dbContext.Salons.FindAsync(technicianDto.SalonId);
            if (associatedSalon == null)
            {
                throw new InvalidOperationException("Salon not found.");
            }

            // Create a new technician without populating SkillSet
            var technician = new Technician
            {
                SalonId = technicianDto.SalonId,
                AssociatedSalon = associatedSalon,
                Name = technicianDto.Name,
                Salary = technicianDto.Salary,
                PayPeriodType = technicianDto.PayPeriodType,
            };

            // Add the technician using the repository
            return await _technicianRepository.AddTechnicianAsync(technician);
        }




        // Update technician 
        public async Task<Technician> UpdateTechnicianAsync(int id, Technician updatedTechnician)
        {
            var existingTechnician = await _technicianRepository.GetTechnicianByIdAsync(id);
            if (existingTechnician == null)
            {
                return null;
            }

            // Update the technician's properties
            existingTechnician.Name = updatedTechnician.Name;
            existingTechnician.Salary = updatedTechnician.Salary;

            // Update in the database
            return await _technicianRepository.UpdateTechnicianAsync(existingTechnician);
        }

        // Delete a technician
        public async Task<bool> DeleteTechnicianAsync(int id)
        {
            return await _technicianRepository.DeleteTechnicianAsync(id);
        }
    }

}