using Microsoft.EntityFrameworkCore;
using SalonSystem.Domain.Entities.Users;
using SalonSystem.Infrastructure.Data;
using SalonSystem.Infrastructure.Repositories.Users.Interfaces;
using SalonSystem.Infrastructure.Repositories.Base.Implementations;

namespace SalonSystem.Infrastructure.Repositories.Users.Implementations
{
    public class SubUserRepository : GenericRepository<SubUser>, ISubUserRepository
    {
        private readonly SalonSystemDbContext _context;

        public SubUserRepository(SalonSystemDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubUser>> GetAllWithOwnersAsync()
        {
            return await _context.SubUsers
                .Include(subUser => subUser.Owner)
                .ToListAsync();
        }

        public async Task<SubUser?> GetByIdWithOwnerAsync(int subUserId)
        {
            return await _context.SubUsers
                .Include(subUser => subUser.Owner)
                .FirstOrDefaultAsync(subUser => subUser.SubUserId == subUserId);
        }

        public async Task<bool> IsSubUserExistsByUsernameAsync(string username)
        {
            return await _context.SubUsers
                .AnyAsync(subUser => subUser.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        }
    }
}
