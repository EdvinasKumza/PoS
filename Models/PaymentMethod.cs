namespace WebApplication1.Models
{
    public class PaymentMethod
    {
        [Key]
        public string PaymentMethodId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
