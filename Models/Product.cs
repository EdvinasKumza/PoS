namespace WebApplication1.Models
{
    public class Product
    {
        [Key]
        public string ProductId { get; set; }
        public string TenantId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int StockLevel { get; set; }
    }
}
