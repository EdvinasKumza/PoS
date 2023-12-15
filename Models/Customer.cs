namespace WebApplication1.Models
{
    public class Customer
    {
        [Key]
        public string CustomerID { get; set; }
        public string Name { get; set; }
        public string ContactDetails { get; set; }
        public int LoyaltyPoints { get; set; }

    }
}
