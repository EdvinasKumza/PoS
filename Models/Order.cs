namespace WebApplication1.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string OrderId { get; set; }
        public string CustomerId { get; set; }
        public string TenantId { get; set; }
        [ForeignKey("Worker")]
        public string PlacedBy { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; } = Decimal.Zero;
        public decimal DiscountApplied { get; set; } = Decimal.Zero;
        public string Status { get; set; } = "Pending";
        public Customer Customer { get; set; }
        public Tenant Tenant { get; set; }
        public Worker Worker { get; set; }
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
