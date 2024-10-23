using System.Collections.Generic;
using System.Threading.Tasks;
using SalonSystem.Models.Salons;

namespace SalonSystem.Data.Repositories 
{
    public interface ISalonRepository 
    {
        Task<IEnumerable<Salon>> GetAllSalonsAsync();
        Task<Salon> GetSalonByIdAsync(int salonId);
        Task<Salon> AddSalonAsync(Salon salon);
        Task<Salon> UpdateSalonAsync(Salon salon);
        Task<bool> DeleteSalonAsync(int salonId); 
    }   
}