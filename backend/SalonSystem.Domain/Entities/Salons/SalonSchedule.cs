namespace SalonSystem.Domain.Entities.Salons
{
    public class SalonSchedule
    {
        public int SalonScheduleId { get; set; }
        public int SalonId { get; set; } 
        public virtual Salon Salon { get; set; } 

        public DayOfWeek Day { get; set; } 
        public TimeSpan OpenTime { get; set; } 
        public TimeSpan CloseTime { get; set; } 
    }
}
