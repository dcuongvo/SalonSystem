using SalonSystem.Domain.Entities.Users;
using SalonSystem.Infrastructure.Repositories.Base.Interfaces;

namespace SalonSystem.Infrastructure.Repositories.Users.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetUserWithSalonsByIdAsync(int userId);
        // Get all users with their associated salons and sub-users
        Task<IEnumerable<User>> GetAllUsersWithDetailsAsync();

        // Get a user by ID with associated salons and sub-users
        Task<User?> GetUserWithDetailsByIdAsync(int userId);

        // Check if a user exists with a specific email
        Task<bool> IsUserExistsByEmailAsync(string email);

        // Get a user by username
        Task<User?> GetUserByUsernameAsync(string username);

        // Get all SubUsers
        Task<IEnumerable<SubUser>> GetAllSubUsersAsync();

        // Get all SubUsers by username
        Task<IEnumerable<SubUser>> GetSubUsersByUsernameAsync(string username);

        // Get all SubUsers by userId
        Task<IEnumerable<SubUser>> GetSubUsersByUserIdAsync(int userId);
    }
}
