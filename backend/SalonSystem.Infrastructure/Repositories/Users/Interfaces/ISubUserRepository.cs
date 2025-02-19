using SalonSystem.Domain.Entities.Users;
using SalonSystem.Infrastructure.Repositories.Base.Interfaces;

namespace SalonSystem.Infrastructure.Repositories.Users.Interfaces
{
    public interface ISubUserRepository : IRepository<SubUser>
    {
        // Get all SubUsers with their owners
        Task<IEnumerable<SubUser>> GetAllWithOwnersAsync();

        // Get SubUser by ID with owner details
        Task<SubUser?> GetByIdWithOwnerAsync(int subUserId);

        // Check if SubUser exists with a specific username
        Task<bool> IsSubUserExistsByUsernameAsync(string username);
    }
}
