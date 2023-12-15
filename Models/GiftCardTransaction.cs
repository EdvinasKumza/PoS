namespace WebApplication1.Models
{
    public class GiftCardTransaction
    {
        [Key]
        public string TransactionId { get; set; }
        public string CardNumber { get; set; }
        public decimal Amount { get; set; }
        public string TransactionDate { get; set; }
        public string OrderId { get; set; }
        public string Type { get; set; }
    }
}
