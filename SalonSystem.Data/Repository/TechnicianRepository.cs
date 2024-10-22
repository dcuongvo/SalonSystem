using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalonSystem.Models.Technicians;

namespace SalonSystem.Data.Repositories 
{
    public class TechnicianRepository : ITechnicianRepository 
    {
        private readonly SalonSystemDbContext  _context;
        public TechnicianRepository(SalonSystemDbContext context) => _context = context;
        
        public async Task<IEnumerable<Technician>> GetAllTechniciansAsync() 
        {
            return await _context.Technicians.ToListAsync();
        }

        public async Task<Technician>GetTechnicianByIdAsync(int technicianId) 
        {
            return await _context.Technicians.FindAsync(technicianId);
        }

        public async Task<Technician> AddTechnicianAsync(Technician technician)
        {
            _context.Technicians.Add(technician);
            await _context.SaveChangesAsync();
            return technician;
        }
        
        public async Task<Technician> UpdateTechnicianAsync(Technician technician) 
        {
            _context.Entry(technician).State = EntityState.Modified;
            await   _context.SaveChangesAsync();
            return technician;
        }
        public async Task<bool> DeleteTechnicianAsync(int technicianId) 
        {
            var techncian = await _context.Technicians.FindAsync(technicianId);
            if (techncian == null ) return false;

            _context.Technicians.Remove(techncian);
            await _context.SaveChangesAsync();
            return true;
        }





    }   


}
