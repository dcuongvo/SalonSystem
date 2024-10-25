using SalonSystem.Commom.Enum;

namespace SalonSystem.DTOs
{
    // DTO for transferring technician data
    public class TechnicianDto
    {
        public int TechnicianId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Salary { get; set; }
        public string PayPeriodType { get; set; }  // Friendly string representation
        public int SalonId { get; set; }
        public string SalonName { get; set; }  // Name of the associated salon for easy reference
    }
}