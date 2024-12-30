
namespace SalonSystem.Domain.Entities.Employees
{
    public class EmployeeSchedule
    {
        public int EmployeeScheduleId { get; set; } 
        public int TechnicianId { get; set; } 
        public virtual required Employee Employee { get; set; } 

        public DateTime StartTime { get; set; } 
        public DateTime EndTime { get; set; }  
        public bool IsAvailable { get; set; } = true; 
        public DayOfWeek Day { get; set; } 
    }
}
