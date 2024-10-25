using SalonSystem.Commom.Enum;

namespace SalonSystem.DTOs
{
    public class UpdateTechnicianDto
    {
        public int TechnicianId { get; set; }  // Assuming you need the ID for updating
        public string Name { get; set; } = string.Empty;
        public int Salary { get; set; }
        public PayPeriod PayPeriodType { get; set; }
    }
}