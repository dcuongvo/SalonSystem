using SalonSystem.Commom.Enum;

namespace SalonSystem.DTOs
{
    // DTO for creating a technician
    public class CreateTechnicianDto
    {
        public int SalonId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Salary { get; set; }
        public PayPeriod PayPeriodType { get; set; }
        //public ICollection<CreateSkillDto> SkillSet { get; set; } = new List<CreateSkillDto>();
    }
}