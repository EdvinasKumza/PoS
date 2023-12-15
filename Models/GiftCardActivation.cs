namespace WebApplication1.Models
{
    public class GiftCardActivation
    {
        [Key]
        public string ActivationId { get; set; }
        public string CardNumber { get; set; }
        public string ActivatedBy { get; set; }
        public string ActivationDate { get; set; }
        public decimal AmountLoaded { get; set; }
    }
}
