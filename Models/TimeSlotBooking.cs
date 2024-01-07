namespace WebApplication1.Models
{
    public class TimeSlotBooking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string BookingId { get; set; }
        public string TimeSlotId { get; set; }
        public DateTime BookingTime { get; set; }
        public string CustomerId { get; set; }
    }
}
