using System.Collections.Generic;
using System.Threading.Tasks;
using SalonSystem.Models.Technicians;

namespace SalonSystem.Data.Repositories 
{
    public interface ITechnicianRepository 
    {
        Task<IEnumerable<Technician>> GetAllTechniciansAsync();
        Task<Technician> GetTechnicianByIdAsync(int technicianId);
        //Task<Technician> GetTechnicianAsync(Technician technician);
        Task<Technician> AddTechnicianAsync(Technician technician);
        Task<Technician> UpdateTechnicianAsync(Technician technician);
        Task<bool> DeleteTechnicianAsync(int technicianId); 
    }   
}