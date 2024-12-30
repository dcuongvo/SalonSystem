using SalonSystem.Domain.Entities.Appointments;

namespace SalonSystem.Domain.Entities.Technicians
{
    public class TechnicianSchedule
    {
        // Primary Key
        public int TechnicianScheduleId { get; set; }

        // Foreign Key to Technician
        public int TechnicianId { get; set; }
        public virtual Technician? Technician { get; set; } // Navigation Property

        // Day of the Week this schedule applies to
        public DayOfWeek Day { get; set; }

        // Shift Timing
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        // Indicates if the technician is available for this schedule
        public bool IsAvailable { get; set; } = true;

        // Navigation Property for associated TimeBlocks
        public virtual ICollection<TimeBlock> TimeBlocks { get; set; } = new List<TimeBlock>();

        // Methods
        public IEnumerable<TimeBlock> GenerateTimeBlocks(int intervalMinutes = 5)
        {
            var blocks = new List<TimeBlock>();
            var currentTime = StartTime;

            while (currentTime < EndTime)
            {
                blocks.Add(new TimeBlock
                {
                    TechnicianScheduleId = this.TechnicianScheduleId,
                    BlockTime = DateTime.Today.Add(currentTime), // Assuming daily schedule, adjust as needed
                    IsAvailable = true
                });
                currentTime = currentTime.Add(TimeSpan.FromMinutes(intervalMinutes));
            }

            return blocks;
        }
    }
}
