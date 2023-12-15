namespace WebApplication1.Models
{
    public class OrderItem
    {
        [Key]
        public string OrderItemId { get; set; }
        public string OrderId { get; set; }
        public string ServiceId { get; set; }
        public int Quantity { get; set; }
    }
}
