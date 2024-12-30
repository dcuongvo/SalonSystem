namespace SalonSystem.Domain.Entities.Users
{
    public class SubUser
    {
        // Primary Key
        public int SubUserId { get; set; }

        // Basic Information
        public string UserName { get; set; } // Unique username
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        // Role and Permissions
        public string Role { get; set; } // E.g., Manager, FrontDesk...
        public bool IsActive { get; set; } = true; 

        // Relationship to Owner
        public int OwnerId { get; set; } // Foreign key to the Owner (User)
        public User Owner { get; set; } // Navigation property to the Owner
    }
}