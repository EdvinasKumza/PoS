namespace WebApplication1.Models
{
    public class InventoryOrderItem
    {
        [Key]
        public string OrderItemId { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public int QuantityOrdered { get; set; }
    }
}
