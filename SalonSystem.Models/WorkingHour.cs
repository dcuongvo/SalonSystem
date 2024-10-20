namespace SalonSystem.Models.WorkingHours {
    public class WorkingHours
    {
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }

        public WorkingHours(TimeSpan openingTime, TimeSpan closingTime)
        {
            OpeningTime = openingTime;
            ClosingTime = closingTime;
        }
    }
}