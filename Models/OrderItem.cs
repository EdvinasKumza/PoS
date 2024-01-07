namespace WebApplication1.Models
{
    public class OrderItem : IValidatableObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string OrderItemId { get; set; }
        public string? ProductId { get; set; }
        public string? ServiceId { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal TotalPrice { get; set; } = Decimal.Zero;
        public Product Product { get; set; }
        public Service Service { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if ((ProductId == null && ServiceId == null) ||
                (ProductId != null && ServiceId == null) ||
                (ProductId == null && ServiceId != null))
            {
                yield return ValidationResult.Success;
            }
            else
            {
                yield return new ValidationResult("Either ProductId or ServiceId should be set, but not both.");
            }
        }
    }
}
