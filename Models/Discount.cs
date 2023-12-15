namespace WebApplication1.Models
{
    public class Discount
    {
        [Key]
        public string DiscountId { get; set; }
        public string Description { get; set; }
        public string Validity { get; set; }
        public decimal AmountOff { get; set; }
        public string CreatedBy { get; set; }
    }
}
