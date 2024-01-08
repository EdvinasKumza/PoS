namespace WebApplication1.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string PaymentId { get; set; }
        public string OrderId { get; set; }
        public string PaymentMethodId { get; set; }
        public decimal Amount { get; set; }
        public Order Order { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
