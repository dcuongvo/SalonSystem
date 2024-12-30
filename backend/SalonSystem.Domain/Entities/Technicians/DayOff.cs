namespace SalonSystem.Domain.Entities.Technicians
{
    public class DayOff
    {
        public int DayOffId { get; set; }
        public int TechnicianId { get; set; } 
        public virtual Technician? Technician { get; set; } 

        public DateTime Date { get; set; } 
        public string Reason { get; set; } = "";
    }
}
