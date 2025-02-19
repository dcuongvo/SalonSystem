using SalonSystem.Domain.Entities.Salons;

namespace SalonSystem.Domain.Entities.Users
{
    public class User
    {
        // Primary Key
        public int UserId { get; set; }

        // Basic Information
        public required string Username { get; set; } // Owner username
        public string Email { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string? PasswordSalt { get; set; }
        public string FirstName {get;set;} = "";
        public string LastName {get;set;} = "";

        // Relationships
        public ICollection<Salon> Salons { get; set; } = new List<Salon>(); // List of salons managed by the owner
        public ICollection<SubUser> SubUsers { get; set; } = new List<SubUser>(); // Managers/FrontDesk users

        // Creation Date
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
