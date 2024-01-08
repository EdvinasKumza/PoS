namespace PoS.Dtos.Order
{
    public class OrderReceiptDto
    {
        public string OrderId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalAmountWithTips { get; set; }
        public decimal TotalItemPrice { get; set; }
        public decimal DiscountApplied { get; set; }
        public decimal Tips { get; set; }
        public string Status { get; set; }
        public List<OrderReceiptItemDto> Items { get; set; } = new List<OrderReceiptItemDto>();
    }

    public class OrderReceiptItemDto
    {
        public string ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
