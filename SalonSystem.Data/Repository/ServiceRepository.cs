using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalonSystem.Models.Services;

namespace SalonSystem.Data.Repositories 
{
    public class ServiceRepository : IServiceRepository 
    {
        private readonly SalonSystemDbContext  _context;
        public ServiceRepository(SalonSystemDbContext context) => _context = context;
        
        public async Task<IEnumerable<Service>> GetAllServicesAsync() 
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<Service>GetServiceByIdAsync(int serviceId) 
        {
            return await _context.Services.FindAsync(serviceId);
        }

        public async Task<Service> AddServiceAsync(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return service;
        }
        
        public async Task<Service> UpdateServiceAsync(Service service) 
        {
            _context.Entry(service).State = EntityState.Modified;
            await   _context.SaveChangesAsync();
            return service;
        }
        public async Task<bool> DeleteServiceAsync(int serviceId) 
        {
            var techncian = await _context.Services.FindAsync(serviceId);
            if (techncian == null ) return false;

            _context.Services.Remove(techncian);
            await _context.SaveChangesAsync();
            return true;
        }





    }   


}
