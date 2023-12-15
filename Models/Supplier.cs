namespace WebApplication1.Models
{
    public class Supplier
    {
        [Key]
        public string SupplierId { get; set; }
        public string Name { get; set; }
        public string ContactDetails { get; set; }
    }
}
