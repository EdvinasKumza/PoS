namespace WebApplication1.Models
{
    public class Tenant
    {
        [Key]
        public string TenantId { get; set; }
        public string BusinessName { get; set; }
        public string ContactDetails { get; set; }
    }
}
