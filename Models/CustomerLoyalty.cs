namespace WebApplication1.Models
{
    public class CustomerLoyalty
    {
        [Key]
        public string CustomerLoyaltyId { get; set; }
        public string CustomerId { get; set; }
        public string LoyaltyProgramId { get; set; }
        public int PointsAccumulated { get; set; }
    }
}
