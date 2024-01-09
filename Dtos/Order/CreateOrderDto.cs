using PoS.Dtos.OrderItem;

namespace PoS.Dtos.Order
{
    public class CreateOrderDto
    {
        public string CustomerId { get; set; }
        public string TenantId { get; set; }
        public string PlacedBy { get; set; }
        public List<OrderItemDto> Items { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; } = Decimal.Zero;
        public decimal DiscountApplied { get; set; } = Decimal.Zero;
        public string Status { get; set; } = "Pending";
        public decimal Tips { get; set; }
        public decimal TotalFee { get; set; }
    }
}
