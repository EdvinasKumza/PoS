namespace WebApplication1.Models
{
    public class InventoryOrder
    {
        [Key]
        public string OrderId { get; set; }
        public string SupplierId { get; set; }
        public string TenantId { get; set; }
        public string OrderDate { get; set; }
        public string ExpectedDeliveryDate { get; set; }
        public string PlacedBy { get; set; }
    }
}
