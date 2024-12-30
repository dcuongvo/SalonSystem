using SalonSystem.Domain.Entities.Salons;

namespace SalonSystem.Domain.Entities.Users
{
    public class User
    {
        // Primary Key
        public int UserId { get; set; }

        // Basic Information
        public string UserName { get; set; } // Owner username
        public string Email { get; set; } // Owner email
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        // Relationships
        public ICollection<Salon> Salons { get; set; } = new List<Salon>(); // List of salons managed by the owner
        public ICollection<SubUser> SubUsers { get; set; } = new List<SubUser>(); // Managers/FrontDesk users

        // Creation Date
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
