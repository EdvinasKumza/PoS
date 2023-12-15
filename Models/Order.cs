namespace WebApplication1.Models
{
    public class Order
    {
        [Key]
        public string OrderId { get; set; }
        public string CustomerId { get; set; }
        public string TenantId { get; set; }
        public string PlacedBy { get; set; }
        public string Date { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountApplied { get; set; }
        public string Status { get; set; }
    }
}
