namespace WebApplication1.Models
{
    public class Service
    {
        [Key]
        public string ServiceId { get; set; }
        public string TenantId { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public int Price { get; set; }
        public Tenant Tenant { get; set; }
    }
}
