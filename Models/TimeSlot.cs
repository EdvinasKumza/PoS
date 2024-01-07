namespace WebApplication1.Models
{
    public class TimeSlot
    {
        [Key]
        public string TimeSlotId { get; set; }
        public string WorkerId { get; set; }
        public string ServiceId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
