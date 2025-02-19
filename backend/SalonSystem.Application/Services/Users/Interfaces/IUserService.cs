using SalonSystem.Domain.Entities.Users;
using SalonSystem.Domain.Entities.Salons;

namespace SalonSystem.Application.Services.Users.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(User user, string password);
        Task<IEnumerable<Salon>> GetUserSalonsAsync(int userId);
        Task<User?> GetUserWithDetailsByIdAsync(int userId);
        Task<IEnumerable<User>> GetAllUsersWithDetailsAsync();
        Task<IEnumerable<SubUser>> GetSubUsersByUserIdAsync(int userId);
        Task<bool> IsUserExistsByEmailAsync(string email);
        Task<bool> DeleteUserAsync(int userId);
        Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword);
        
    }
}
