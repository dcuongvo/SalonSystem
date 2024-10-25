using SalonSystem.Commom.Enum;

namespace SalonSystem.DTOs
{
    public class SalonDto
    {
        public int SalonId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<SimpleTechnicianDto> Technicians { get; set; } = new List<SimpleTechnicianDto>();
    }

        public class SimpleTechnicianDto
    {
        public int TechnicianId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}