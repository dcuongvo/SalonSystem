using Microsoft.EntityFrameworkCore;
using SalonSystem.Domain.Entities.Users;
using SalonSystem.Infrastructure.Data;
using SalonSystem.Infrastructure.Repositories.Base.Implementations;
using SalonSystem.Infrastructure.Repositories.Users.Interfaces;

namespace SalonSystem.Infrastructure.Repositories.Users.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly SalonSystemDbContext _context;

        public UserRepository(SalonSystemDbContext context) : base(context)
        {
            _context = context;
        }
        
        public async Task<User?> GetUserWithSalonsByIdAsync(int userId)
        {
            return await _context.Users
                .Include(user => user.Salons) // Include the Salons collection
                .FirstOrDefaultAsync(user => user.UserId == userId);
        }

        public async Task<IEnumerable<User>> GetAllUsersWithDetailsAsync()
        {
            return await _context.Users
                .Include(user => user.Salons)
                .Include(user => user.SubUsers)
                .ToListAsync();
        }

        public async Task<User?> GetUserWithDetailsByIdAsync(int userId)
        {
            return await _context.Users
                .Include(user => user.Salons)
                .Include(user => user.SubUsers)
                .FirstOrDefaultAsync(user => user.UserId == userId);
        }

        public async Task<bool> IsUserExistsByEmailAsync(string email)
        {
            return await _context.Users
                .AnyAsync(user => EF.Functions.Like(user.Email, email));
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .Include(user => user.Salons)
                .Include(user => user.SubUsers)
                .FirstOrDefaultAsync(user => EF.Functions.Like(user.Username, username));
        }

        public async Task<IEnumerable<SubUser>> GetAllSubUsersAsync()
        {
            return await _context.SubUsers
                .Include(subUser => subUser.Owner)
                .ToListAsync();
        }

        public async Task<IEnumerable<SubUser>> GetSubUsersByUsernameAsync(string username)
        {
            return await _context.SubUsers
                .Where(subUser => subUser.Owner != null && EF.Functions.Like(subUser.Owner.Username, username))
                .Include(subUser => subUser.Owner)
                .ToListAsync();
        }

        public async Task<IEnumerable<SubUser>> GetSubUsersByUserIdAsync(int userId)
        {
            return await _context.SubUsers
                .Where(subUser => subUser.OwnerId == userId)
                .Include(subUser => subUser.Owner)
                .ToListAsync();
        }
    }
}
