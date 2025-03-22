namespace SleepTrackerApi.Models
{
    public class SleepRecord
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int UserId { get; set; }

        public User User { get; set; } // Связь с пользователем
    }
}
