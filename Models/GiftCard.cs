using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class GiftCard
    {
        [Key]
        public string CardNumber { get; set; }
        public string TenantId { get; set; }
        public string ActivationDate { get; set; }
        public string ExpirationDate { get; set; }
        public decimal Balance { get; set; }
    }
}
