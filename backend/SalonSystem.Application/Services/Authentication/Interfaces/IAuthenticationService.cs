using SalonSystem.Domain.Entities.Users;

namespace SalonSystem.Application.Services.Authentication.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string?> LoginUserAsync(string username, string password);
    }
}
