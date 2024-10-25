using System.Collections.Generic;
using System.Threading.Tasks;
using SalonSystem.Models.Services;

namespace SalonSystem.Data.Repositories 
{
    public interface IServiceRepository 
    {
        Task<IEnumerable<Service>> GetAllServicesAsync();
        Task<Service> GetServiceByIdAsync(int serviceId);
        //Task<Service> GetServiceAsync(Service service);
        Task<Service> AddServiceAsync(Service service);
        Task<Service> UpdateServiceAsync(Service service);
        Task<bool> DeleteServiceAsync(int serviceId); 
    }   
}