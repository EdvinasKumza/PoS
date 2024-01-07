namespace WebApplication1.Models
{
    public class Worker
    {
        [Key]
        public string WorkerId { get; set; }
        public string TenantId { get; set; }
        public string Name { get; set; }
        public string UniqueCode { get; set; }
        public string RoleId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
