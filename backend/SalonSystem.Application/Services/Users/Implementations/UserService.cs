using System.Security.Cryptography;
using System.Text;
using SalonSystem.Domain.Entities.Users;
using SalonSystem.Domain.Entities.Salons;
using SalonSystem.Infrastructure.Repositories.Users.Interfaces;
using SalonSystem.Application.Services.Users.Interfaces;

namespace SalonSystem.Application.Services.Users.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> RegisterUserAsync(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(user.Username) ||
                string.IsNullOrWhiteSpace(user.FirstName) ||
                string.IsNullOrWhiteSpace(user.LastName) ||
                string.IsNullOrWhiteSpace(user.Email) ||
                string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Username, Password, FirstName, LastName, and Email are required.");
            }
            // Check if username already exists
            var existingUserByUsername = await _userRepository.GetUserByUsernameAsync(user.Username);
            if (existingUserByUsername != null)
            {
                throw new InvalidOperationException("Username is already taken.");
            }
            // Check if email already exists
            var existingUserByEmail = await _userRepository.IsUserExistsByEmailAsync(user.Email);
            if (existingUserByEmail)
            {
                throw new InvalidOperationException("An account with this email already exists.");
            }
            // Hash the password
            using var hmac = new HMACSHA512();
            user.PasswordSalt = Convert.ToBase64String(hmac.Key);
            user.PasswordHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));

            // Add the user
            return await _userRepository.AddAsync(user);
        }

        public async Task<IEnumerable<Salon>> GetUserSalonsAsync(int userId)
        {
            var user = await _userRepository.GetUserWithSalonsByIdAsync(userId);
            return user?.Salons ?? Enumerable.Empty<Salon>();
        }



        public async Task<User?> GetUserWithDetailsByIdAsync(int userId)
        {
            return await _userRepository.GetUserWithDetailsByIdAsync(userId);
        }

        public async Task<IEnumerable<User>> GetAllUsersWithDetailsAsync()
        {
            return await _userRepository.GetAllUsersWithDetailsAsync();
        }

        public async Task<IEnumerable<SubUser>> GetSubUsersByUserIdAsync(int userId)
        {
            return await _userRepository.GetSubUsersByUserIdAsync(userId);
        }

        public async Task<bool> IsUserExistsByEmailAsync(string email)
        {
            return await _userRepository.IsUserExistsByEmailAsync(email);
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            return await _userRepository.DeleteAsync(userId);
        }

        public async Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword)
        {
            var user = await _userRepository.GetUserWithDetailsByIdAsync(userId);
            if (user == null) return false;

            using var hmac = new HMACSHA512(Convert.FromBase64String(user.PasswordSalt!));
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(currentPassword));
            if (Convert.ToBase64String(computedHash) != user.PasswordHash) return false;

            using var newHmac = new HMACSHA512();
            user.PasswordSalt = Convert.ToBase64String(newHmac.Key);
            user.PasswordHash = Convert.ToBase64String(newHmac.ComputeHash(Encoding.UTF8.GetBytes(newPassword)));

            return await _userRepository.UpdateAsync(user);
        }
    }
}
