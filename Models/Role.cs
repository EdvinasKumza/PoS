namespace WebApplication1.Models
{
    public class Role
    {
        [Key]
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
