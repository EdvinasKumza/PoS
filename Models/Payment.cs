namespace WebApplication1.Models
{
    public class Payment
    {
        [Key]
        public string PaymentId { get; set; }
        public string OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
    }
}
