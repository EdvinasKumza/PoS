namespace WebApplication1.Models
{
    public class Permission
    {
        [Key]
        public string PermissionId { get; set; }
        public string PermissionName { get; set; }
        public string Description { get; set; }
    }
}
