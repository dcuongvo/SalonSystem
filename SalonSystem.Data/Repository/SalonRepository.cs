using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalonSystem.Models.Salons;

namespace SalonSystem.Data.Repositories 
{
    public class SalonRepository : ISalonRepository 
    {
        private readonly SalonSystemDbContext  _context;
        public SalonRepository(SalonSystemDbContext context) => _context = context;
        
        public async Task<IEnumerable<Salon>> GetAllSalonsAsync() 
        {
            return await _context.Salons.ToListAsync();
        }

        public async Task<Salon>GetSalonByIdAsync(int salonId) 
        {
            return await _context.Salons.FindAsync(salonId);
        }

        public async Task<Salon> AddSalonAsync(Salon salon)
        {
            _context.Salons.Add(salon);
            await _context.SaveChangesAsync();
            return salon;
        }
        
        public async Task<Salon> UpdateSalonAsync(Salon salon) 
        {
            _context.Entry(salon).State = EntityState.Modified;
            await   _context.SaveChangesAsync();
            return salon;
        }
        public async Task<bool> DeleteSalonAsync(int salonId) 
        {
            var techncian = await _context.Salons.FindAsync(salonId);
            if (techncian == null ) return false;

            _context.Salons.Remove(techncian);
            await _context.SaveChangesAsync();
            return true;
        }
    }   
}
