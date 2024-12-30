using SalonSystem.Domain.Entities.Salons;

namespace SalonSystem.Domain.Entities.Salons
{
    public class DayClose
    {
        public int DayCloseId { get; set; } // Primary Key
        public int SalonId { get; set; } // Foreign Key
        public virtual Salon? Salon { get; set; } // Navigation Property

        public DateTime Date { get; set; } // Specific date the salon is closed
        public string Reason { get; set; } = "";
    }
}
