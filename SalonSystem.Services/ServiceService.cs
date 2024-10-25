using SalonSystem.Data.Repositories;
using SalonSystem.Models.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalonSystem.Services 
{
    public class ServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        // Get all services
        public async Task<IEnumerable<Service>> GetAllServicesAsync()
        {
            return await _serviceRepository.GetAllServicesAsync();
        }

        // Get service by ID
        public async Task<Service> GetServiceByIdAsync(int id)
        {
            return await _serviceRepository.GetServiceByIdAsync(id);
        }

        // Add new service
        public async Task<Service> AddServiceAsync(Service service)
        {
            // need to update more logic after adding salon service
            return await _serviceRepository.AddServiceAsync(service);
        }

        // Update service 
        public async Task<Service> UpdateServiceAsync(int id, Service service)
        {
            if (id != service.ServiceId)
            {
                return null; //revisit
            }

            return await _serviceRepository.UpdateServiceAsync(service);
        }

        // Delete a service
        public async Task<bool> DeleteServiceAsync(int id)
        {
            return await _serviceRepository.DeleteServiceAsync(id);
        }
    }

}