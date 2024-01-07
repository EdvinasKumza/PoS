using PoS.Dtos.OrderItem;

namespace PoS.Dtos.Order
{
    public class CreateOrderDto
    {
        public string CustomerId { get; set; }
        public string TenantId { get; set; }
        public string PlacedBy { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }
}
